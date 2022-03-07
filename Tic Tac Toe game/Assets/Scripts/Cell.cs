using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    int row, col;
    Status status;
    public delegate void StatusUpdate(Status status);
    public StatusUpdate statusUpdate;

    public delegate void RowAndCol(int row, int col);
    public RowAndCol rowcol;


    public enum Status { None ,Cross,Circle,Win,Loose}

    public Cell()
    {
        row = 0;
        col = 0;
        this.status = Status.None;
    }
    public Cell(int row,int col)
    {
        this.row = row;
        this.col = col;
        this.status = Status.None;
    }
    public void SetStatus( Status status)
    {
        this.status = status;
        statusUpdate?.Invoke(status);
    }
    public Status GetStatus()
    {
        return status;
    }
    public void setRow(int row)
    {
        this.row = row;
    }

    internal void Interection()
    {
      //  SetStatus(Status.Win);
        rowcol?.Invoke(row, col);
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


}
