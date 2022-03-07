using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    public GameObject[] cellStatus;
    Cell cell = new Cell();
    // Start is called before the first frame update
    public void SetStatus(Cell.Status status)
    {
        for (int i = 0; i < cellStatus.Length; i++)
        {
            if (i == (int)status)
            {
                cellStatus[i].SetActive(true);
            }
            else
                cellStatus[i].SetActive(false);
        }
    }
    
    void Start()
    {
        cell.statusUpdate += SetStatus;

    }

    private void OnMouseDown()
    {
        cell.Interection();
    }

    internal void setCell(Cell cell)
    {
        this.cell = cell;
    }
}
