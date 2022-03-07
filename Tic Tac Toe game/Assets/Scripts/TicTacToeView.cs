using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int inputRow;
    public int inputCol;
    private float horizontalSpacing=0;
    private float verticalSpacing=0;

    public GameObject CellPf;

    int tempCounter = 0;
   
   

    TicTacToeGrid TTTGrid;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGrid();
    }


    private void InitializeGrid()
    {
        Debug.Log("Initialize Grid is working");

        TTTGrid = new TicTacToeGrid(inputRow, inputCol);
        TTTGrid.onCellCreated += OnCellCreated;
        TTTGrid.onAllCellDone += AllignCell;
        TTTGrid.InitializeCells(inputRow, inputCol);
    }

   

    private void OnCellCreated(Cell cell)
    {
        AllignCell();
        GameObject cellViewtemp = Instantiate(CellPf, new Vector3(horizontalSpacing, 0, verticalSpacing), CellPf.transform.rotation);
        cellViewtemp.GetComponent<CellView>().setCell(cell);
        cellViewtemp.GetComponent<CellView>().SetStatus(Cell.Status.None);
        tempCounter++;

    }

    private void AllignCell()
    {
        CellPosition();
    }

    private void CellPosition()
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
