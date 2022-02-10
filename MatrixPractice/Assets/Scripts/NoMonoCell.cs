using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMonoCell 
{
    public int row;
    public int col;

    Status status;

    public delegate void StatusUpdated(Status status);
    public StatusUpdated statusUpdated;
    public enum Status { None, Cross, Circle, Win, Losse }

    public NoMonoCell()
    {
        row = 0;
        col = 0;
    }
    public NoMonoCell(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
    public void setStatus(Status status)
    {
        this.status = status;
        statusUpdated.Invoke(status);

    }
    public Status getStatus()
    {

        return status;
    }
    public void setRow(int row)
    {
        this.row = row;
    }
    public void setCol(int col)
    {
        this.col = col;
    }
    public int getRow()
    {

        return row;
    }
    public int getCol()
    {

        return col;
    }

    internal void CellInteraction()
    {
        setStatus(Status.Losse);
    }
}
