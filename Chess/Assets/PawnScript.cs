using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PawnScript : MonoBehaviour
{
    public GameObject spotReference;

    private PieceBehaviour pb;
    private GameObject[] tileList;

    private void Start()
    {
        pb = GetComponent<PieceBehaviour>();
    }

    private void GetTiles()
    {
        tileList = GameObject.FindGameObjectsWithTag("Tile");
    }

    public void PawnPath()
    {
        GetTiles();
        if (pb.row == 6)
        {
            var frontTile1 = tileList[((pb.row - 1) * 8) + pb.col];
            var frontTile2 = tileList[((pb.row - 2) * 8) + pb.col];

            if (frontTile1.GetComponent<TileBehaviour>().piece == null && frontTile1.GetComponent<TileBehaviour>().piece == null)
            {
                GameObject spot1 = (GameObject)Instantiate(spotReference, transform);
                GameObject spot2 = (GameObject)Instantiate(spotReference, transform);

                spot1.transform.position = frontTile1.transform.position;
                spot1.transform.DOMoveY(-0.8f, 0.02f);

                spot2.transform.position = frontTile2.transform.position;
                spot2.transform.DOMoveY(-0.8f, 0.02f);
            }
        }
        else
        {

        }
    }
}
