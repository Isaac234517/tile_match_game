using UnityEngine;
using System.Collections;
using System;

public class ShapeArray
{
    private GameObject[,] shapes = new GameObject[Constants.Rows, Constants.Columns];

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
}
