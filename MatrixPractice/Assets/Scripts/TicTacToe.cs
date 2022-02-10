using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MatrixUsingArrays 
{
    NoMonoCell[,] nonMono;
    int numOfRows;
    int numOfCol;

    public delegate void OnCellCreated(NoMonoCell nonmonocell);
    public event OnCellCreated onCellCreated;
    public delegate void OnAllCellDone();
    public event OnAllCellDone onAllCellDone;


    public TicTacToe(int row ,int col):base( row,  col)
    {

        Debug.Log("TicTacToe IsWorking");
        InitializeCell(row, col);
    }
    public void InitializeCell(int row, int col)
    {
        nonMono = new NoMonoCell[row, col];
        numOfRows = nonMono.GetLength(0);
        numOfCol = nonMono.GetLength(1);

        for (int i = 0; i < nonMono.GetLength(0); i++)
        {
            for (int j = 0; j < nonMono.GetLength(1); j++)
            {
                nonMono[i, j] = new NoMonoCell();
                
                onCellCreated?.Invoke(nonMono[i, j]);
                //  Debug.Log("TicTacToe initialize Is Working");
            }
        }

      //  Debug.Log("TicTacToe initialize Is Working");
        onAllCellDone?.Invoke();

    }
    public override void OnMatrixUpdated()
    {
      for(int i=0;i<numOfRows;i++)
        {
            for(int j=0;j<numOfCol;j++)
            {
                nonMono[i, j].setStatus((NoMonoCell.Status)GetElement(i, j));
            }

        }
    }
    public void CellStatusSetRequest(int row,int col)
    {
        if (nonMono[row, col].getStatus() == NoMonoCell.Status.None) 
        {
            SetElement(row, col, (int)CurrentTurn());
        }
    }

    private int CurrentTurn()
    {
        return 0;
    }
}
   

