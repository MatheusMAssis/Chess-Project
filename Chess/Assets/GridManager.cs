using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 8;
    private int cols = 8;
    private float tileSize = 1.5f;

    public GameObject referenceTile;

    public void GenerateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector3(posX, 0, posY);
            }
        }

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector3((-gridW / 2) + (tileSize / 2), -1f, (gridH / 2) - (tileSize / 2)); 
    }
}
