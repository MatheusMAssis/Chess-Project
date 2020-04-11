using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    [Header("Grid")]
    public GameObject gridManager;

    [Header("Black Pieces")]
    public GameObject blackPawn;
    public GameObject blackKnight;
    public GameObject blackBishop;
    public GameObject blackRook;
    public GameObject blackQueen;
    public GameObject blackKing;

    [Header("White Pieces")]
    public GameObject whitePawn;
    public GameObject whiteKnight;
    public GameObject whiteBishop;
    public GameObject whiteRook;
    public GameObject whiteQueen;
    public GameObject whiteKing;


    private int rows = 8;
    private int cols = 8;
    private GameObject[] tileList;

    private void Start()
    {
        gridManager.GetComponent<GridManager>().GenerateGrid();
        GetTiles();
        GeneratePieces();
    }

    private void GetTiles()
    {
        tileList = GameObject.FindGameObjectsWithTag("Tile");
    }

    private void CreateAndMovePiece(GameObject _object, int row, int col)
    {
        GameObject piece = (GameObject)Instantiate(_object, transform);
        GameObject tile = tileList[(row * 8) + col];

        float posX = tile.transform.position.x;
        float posY = tile.transform.position.z;
        piece.transform.position = new Vector3(posX, 0f, posY);

        tile.GetComponent<TileBehaviour>().piece = piece;
        piece.GetComponent<PieceBehaviour>().row = row;
        piece.GetComponent<PieceBehaviour>().col = col;
    }

    private void GenerateBackrow(bool color, int row, int col)
    {
        if (color)
        {
            if (col == 0 || col == 7)
                CreateAndMovePiece(blackRook, row, col);
            else if (col == 1 || col == 6)
                CreateAndMovePiece(blackKnight, row, col);
            else if (col == 2 || col == 5)
                CreateAndMovePiece(blackBishop, row, col);
            else if (col == 3)
                CreateAndMovePiece(blackQueen, row, col);
            else if (col == 4)
                CreateAndMovePiece(blackKing, row, col);
        }

        else
        {
            if (col == 0 || col == 7)
                CreateAndMovePiece(whiteRook, row, col);
            else if (col == 1 || col == 6)
                CreateAndMovePiece(whiteKnight, row, col);
            else if (col == 2 || col == 5)
                CreateAndMovePiece(whiteBishop, row, col);
            else if (col == 3)
                CreateAndMovePiece(whiteQueen, row, col);
            else if (col == 4)
                CreateAndMovePiece(whiteKing, row, col);
        }
    }

    private void GeneratePieces()
    {
        for (int row = 0; row < rows; row++)
        {
            if (row == 0)
            {
                for (int col = 0; col < cols; col++)
                {
                    GenerateBackrow(true, row, col);
                }
            }

            if (row == 1)
            {
                for (int col = 0; col < cols; col++)
                {
                    CreateAndMovePiece(blackPawn, row, col);
                }
            }

            if (row == 6)
            {
                for (int col = 0; col < cols; col++)
                {
                    CreateAndMovePiece(whitePawn, row, col);
                }
            }

            if (row == 7)
            {
                for (int col = 0; col < cols; col++)
                {
                    GenerateBackrow(false, row, col);
                }
            }
        }
    }
}
