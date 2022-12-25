using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    private string connectionString;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private Transform scoreParent;
    private List<Highscore> highscores = new List<Highscore>();

    [SerializeField] private TMP_Text enterName;
    [SerializeField] private GameObject nameDialog;
    private string playerName;
    void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/DB/Highscore.db";
        CreateTable();
        // ClearScores();
        ShowScores();
        // GetScores();
    }

    

    private void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("CREATE TABLE IF NOT EXISTS \"Highscores\"(\"PlayerID\"  INTEGER NOT NULL UNIQUE,\"PlayerName\"    TEXT NOT NULL,\"TimeReached\"   TEXT,\"DateReached\"   datetime,PRIMARY KEY(\"PlayerID\" AUTOINCREMENT));");

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    public void EnterName()
    {
        nameDialog.SetActive(true);
    }
    public void CloseNameMenu()
    {
        nameDialog.SetActive(false);
    }
    public void ConfirmName()
    {
        if (enterName.text != string.Empty)
        {
            InsertName(enterName.text);
            playerName = enterName.text;
            enterName.text = string.Empty;
            InsertScore();
        }
        nameDialog.SetActive(false);
    }
    private void InsertName(string name)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("INSERT INTO Highscores(PlayerName) VALUES(\"{0}\");", name);

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void GetScores()
    {
        highscores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Highscores;";

                dbCommand.CommandText = sqlQuery;

                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highscores.Add(new Highscore(reader.GetInt32(0), reader.GetString(2), reader.GetString(1), reader.GetDateTime(3)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        // highscores.Sort();
    }

    public void ClearScores()
    {
        ShowScores();


        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM Highscores");

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void ShowScores()
    {
        GetScores();

        for (int i = 0; i < highscores.Count; i++)
        {
            GameObject tempObject = Instantiate(scorePrefab);

            Highscore tmpScore = highscores[i];

            tempObject.GetComponent<HighScoreScript>().SetScore(tmpScore.name, tmpScore.score.ToString(), "#" + (i + 1).ToString());
            tempObject.transform.SetParent(scoreParent);
            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void InsertScore()
    {

        int minutes = (int)(Time.timeAsDouble / 60f);
        int seconds = (int)(Time.timeAsDouble % 60f);
        TimeSpan timeSpan = new TimeSpan(0, minutes, seconds);
        // string timeReached = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>().text;

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("UPDATE Highscores SET TimeReached=\"{0}\", DateReached=CURRENT_DATE WHERE PlayerName=\"{1}\";", timeSpan.ToString(), playerName);

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
}
