using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid 
{
    private int columns;
    private int height;
    private int rows;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int columns, int height, int rows,  float cellSize)
    {
        this.columns = columns;
        this.height = height;
        this.rows = rows;
        this.cellSize = cellSize;
        

        gridArray = new int[columns, rows];

        for (int x = 0; x<gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y, this.height), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }
    private Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z/cellSize) * cellSize;
    }
}
