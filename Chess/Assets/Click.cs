using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public ClickManager clickManager;

    private void Start()
    {
        clickManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ClickManager>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickManager.actualPieceClicked != null)
                clickManager.lastPieceClicked = clickManager.actualPieceClicked;
            clickManager.actualPieceClicked = gameObject;

            clickManager.OnClick();
        }
    }
}
