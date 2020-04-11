using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickManager : MonoBehaviour
{
    public GameObject lastPieceClicked;
    public GameObject actualPieceClicked;
    public GameObject selectedPiece;

    private GameObject[] spotList;

    private void Check()
    {
        if (actualPieceClicked == lastPieceClicked)
        {
            if (actualPieceClicked.transform.position.y > 0f)
            {
                actualPieceClicked.transform.DOMoveY(0f, 1);
                selectedPiece = null;
            }
            else if (actualPieceClicked.transform.position.y == 0f)
            {
                actualPieceClicked.transform.DOMoveY(1f, 1);
                selectedPiece = actualPieceClicked;
            }
        }
    }

    public void OnClick()
    {
        if (lastPieceClicked != null)
        {
            lastPieceClicked.transform.DOMoveY(0f, 1);
            selectedPiece = null;
        }
        if (actualPieceClicked != null)
        {
            actualPieceClicked.transform.DOMoveY(1f, 1);
            selectedPiece = actualPieceClicked;
        }

        Check();
        ShowSpots();
    }

    private void GetSpots()
    {
        spotList = GameObject.FindGameObjectsWithTag("Spot");
    }

    public void ShowSpots()
    {
        if (selectedPiece != null)
        {
            if (selectedPiece.GetComponent<PieceBehaviour>().category == "Pawn")
            {
                selectedPiece.GetComponent<PawnScript>().PawnPath();
            }
        } else
        {
            GetSpots();
            foreach(GameObject spot in spotList)
            {
                Destroy(spot);
            }
        }
    }
}
