using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int inputRow;
    public int inputCol;
    public float horizontalSpacing;
    public float verticalSpacing;

    public GameObject CellPf;

    int tempCounter = 0;
    //List<GameObject> unityCell = new List<GameObject>();

    TicTacToe TTTGrid;
    private void Start()
    {
        InitializeGrid();
        Debug.Log("view is working");
    }

    private void InitializeGrid()
    {
        Debug.Log("HussainZaidi");
        TTTGrid = new TicTacToe(inputRow, inputCol);
        TTTGrid.onCellCreated += OnCellCreated;
        TTTGrid.onAllCellDone += AllignCell;
        TTTGrid.InitializeCell(inputRow, inputCol);
    }



    public void OnCellCreated(NoMonoCell nonmonocell)
    {
        CellPosition();
       // Vector3 position
        GameObject cellView = Instantiate(CellPf, new Vector3(horizontalSpacing, 0, verticalSpacing), CellPf.transform.rotation);
        //unityCell.Add(cellView);
        tempCounter++;
        cellView.GetComponent<UnityCell>().setNonMono(nonmonocell);
        cellView.GetComponent<UnityCell>().SetStatus(NoMonoCell.Status.None);
    }
    public void AllignCell()
    {
       
    }
    public void CellPosition()
    {
        if (tempCounter == inputRow)
        {
            horizontalSpacing = 2;
            tempCounter = 0;
            verticalSpacing += 2;
        }
        else
        {
            horizontalSpacing += 2;
        }
    }
}
