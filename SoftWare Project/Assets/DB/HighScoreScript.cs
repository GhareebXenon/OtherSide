using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;

    public void SetScore(string name, string score, string rank)
    {
        this.rank.GetComponent<TMP_Text>().text = rank;
        this.scoreName.GetComponent<TMP_Text>().text = name;
        this.score.GetComponent<TMP_Text>().text = score;
    }
}
