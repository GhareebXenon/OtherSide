using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWorld : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0, 0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPlayerPos;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;
    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;
    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;
    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];

    }

    private void Start() {
        UpdateTileOnScreen();
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.x -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPos.x = CalcTileGridPlayerPos(onTileGridPlayerPos.x, true);
            onTileGridPlayerPos.y = CalcTileGridPlayerPos(onTileGridPlayerPos.y, false);
            UpdateTileOnScreen();
        }
    }

    private void UpdateTileOnScreen()
    {
        for (int vision_x = -(fieldOfVisionWidth / 2); vision_x <= fieldOfVisionWidth/2; vision_x++)
        {
            for (int vision_y = -(fieldOfVisionHeight / 2); vision_y <= fieldOfVisionHeight/2; vision_y++)
            {
                int tileToUpdate_x = CalcTileGridPlayerPos(playerTilePosition.x + vision_x, true);
                int tileToUpdate_y = CalcTileGridPlayerPos(playerTilePosition.y + vision_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalcTilePos(playerTilePosition.x + vision_x, playerTilePosition.y + vision_y);
            }
        }
    }

    private Vector3 CalcTilePos(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }
    private int CalcTileGridPlayerPos(float currentValue, bool horizontal)
    {

        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
