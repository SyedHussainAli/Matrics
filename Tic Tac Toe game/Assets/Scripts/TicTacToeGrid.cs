using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    int numOfRow;
    int numOfCol;
   // int win = 0;


    Cell[,] cellGrid;
    Cell.Status currentTurn = Cell.Status.Cross;

    public delegate void OnCellCreated(Cell cell);
    public OnCellCreated onCellCreated;

    public delegate void OnAllCellDone();
    public OnAllCellDone onAllCellDone;
    public TicTacToeGrid(int row,int col):base(row,col)
    {
        Debug.Log("Tic tac toe class is working");
    }

    public void InitializeCells(int row ,int col)
    {
        cellGrid = new Cell[row, col];
        numOfRow = cellGrid.GetLength(0);
        numOfCol = cellGrid.GetLength(1);
        for (int i = 0; i < cellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < cellGrid.GetLength(1); j++)
            {
                cellGrid[i, j] = new Cell(i, j);
                onCellCreated?.Invoke(cellGrid[i,j]);
                cellGrid[i, j].rowcol += SetStatusTurn;
            }
        }
        onAllCellDone?.Invoke();
     
    }

    private void SetStatusTurn(int row, int col)
    {
        if((int)cellGrid[row,col].GetStatus()==(int)Cell.Status.None)
        {
            TakeTurn(row, col);
            //  cellGrid[row, col].SetStatus(currentTurn);
            SetElement(row, col, (int)currentTurn);
          //  Print();
           
            CheckWin(row,col);
        }

      
    }

    private void CheckWin(int row ,int col)
    {
        CheckRow(row);
        CheckCol(col);
        if(row==col)
        CheckDiagonal();
        if(row==cellGrid.GetLength(0)-1-col)
        CheckInverseDiagonal();
    }

    private void CheckInverseDiagonal()
    {
        if (isInverseDiagonalSame())
        { SetInverseDiagonal((int)Cell.Status.Win); }
    }

    private void CheckDiagonal()
    {
       if(isDiagonalSame())
        { SetDiagonal((int)Cell.Status.Win); }
    }

    private void CheckCol(int col)
    {
     if(isColSame(col))
        {
            SetCol(col, (int)Cell.Status.Win);
        }
    }

    private void CheckRow(int row)
    {

        if (isRowSame(row))
        {
            SetRow(row, (int)Cell.Status.Win);
        }
    }

    private void TakeTurn(int row, int col)
    {
        if (currentTurn == Cell.Status.Cross)
        {
            currentTurn = Cell.Status.Circle;
        }
        else
        {
            currentTurn = Cell.Status.Cross;
        }
    }


    public override void OnMatrixUpdated()
    {
        for (int i = 0; i < numOfRow; i++)
        {
            for (int j = 0; j < numOfCol; j++)
            {
                cellGrid[i, j].SetStatus((Cell.Status)GetElement(i, j));
            }

        }
    }
}
