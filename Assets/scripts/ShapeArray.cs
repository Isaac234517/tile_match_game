using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class ShapeArray
{
    private GameObject[,] shapes = new GameObject[Constants.Rows, Constants.Columns];

    private GameObject backup1, backup2;

    public GameObject this[int row, int col]
    {
        get
        {
            try
            {
                return shapes[row, col];
            }

            catch(Exception ex)
            {
                throw; 
            }
        }

        set
        {
            try
            {
                shapes[row, col] = value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public void Swap(GameObject item1, GameObject item2)
    {
        backup1 = item1;
        backup2 = item2;
        Shape shape1 = item1.GetComponent<Shape>();
        Shape shape2 = item2.GetComponent<Shape>();
        GameObject temp = shapes[shape1.row, shape1.col];
        shapes[shape1.row, shape1.col] = shapes[shape2.row, shape2.col];
        shapes[shape2.row, shape2.col] = temp;

    }

    public void unDoSwap(GameObject itme1, GameObject itme2)
    {
        Swap(backup1, backup2);
    }

    private List<GameObject> GetEntireRow(GameObject item)
    {
        List<GameObject> rows = new List<GameObject>();
        int row = item.GetComponent<Shape>().row;
        for(int col =0; col < Constants.Columns;  col++)
        {
            rows.Add(shapes[row, col]);
        }

        return rows;
    }

    private List<GameObject> GetEntireColumn(GameObject item)
    {
        List<GameObject> columns = new List<GameObject>();
        int col = item.GetComponent<Shape>().col;
        for(int row =0; row < Constants.Rows; row++)
        {
            columns.Add(shapes[row, col]);
        }

        return columns;
    }
}
