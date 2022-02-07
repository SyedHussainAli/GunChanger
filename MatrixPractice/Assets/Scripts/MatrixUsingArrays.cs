using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixUsingArrays 
{
   private int row, column;
    int[,] array;

    public MatrixUsingArrays()
    { }
    public MatrixUsingArrays(int row,int col)
    {
        array = new int[row, col];
        for(int i=0;i<row; i++)
        {
            for(int j=0;j<col;j++)
            {
                array[i, j] = 0;
            }
        }
    }

    public MatrixUsingArrays(int[,]arrayout)
    {
        array = arrayout;
    }
    public void Print()
    {
        if (array != null)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Debug.Log(array[i, j]);
                }
            }
        }
        else
            Debug.Log("Array is null");
     
    }
    public void SetMatrix(int[,] arrayout)
    {
        array = arrayout;

    }
    public void SetElement(int row ,int col,int value)
    {
        if(row< array.GetLength(0)&&col< array.GetLength(1))
        array[row, col] = value;
    }

    public int GetElement(int row,int col)
    {
        return array[row, col];
    }

    public void SetRow(int row,int[]arrayy) 
    {
        for(int i=0;i<arrayy.Length;i++)
        {
            array[row, i] = arrayy[i];
        }
    }
    public void SetCol(int col, int[] arrayy)
    {
        for (int i = 0; i < arrayy.Length; i++)
        {
            array[i,col] = arrayy[i];
        }
    }

    public void SwapRows(int row1,int row2)
    {
        for(int i = 0; i < array.GetLength(1); i++)
        {
            int temp = array[row1, i];
            array[row1, i] = array[row2, i];
            array[row2, i] = temp;
        }
    }
    public void SwapCol(int col1,int col2)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            int temp = array[i, col1];
            array[i, col1] = array[i, col2];
            array[i, col2] = temp;
        }
    }

    public void Add(int[,] arraytoAdd)
    {
        for(int i=0;i<array.GetLength(0);i++)
        {
            for(int j=0;j<array.GetLength(1);j++)
            {
                array[i, j] = array[i, j] + arraytoAdd[i, j];
            }
        }
    }
    public void Subtract(int[,] arraytoSubtrat)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = array[i, j] - arraytoSubtrat[i, j];
            }
        }
    }


    public void SetMatrix(int number)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = number;
            }
        }

    }
    public void SetRow(int row,int number)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            array[row, i] = number;
        }

    }
    public void SetCol(int col, int number)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            array[i, col] = number;
        }

    }
    public void SetDiagonal(int num)
    {
        for(int i=0;i<array.GetLength(0);i++)
        {
            array[i, i] = num;
        }
    }
    public void SetInverseDiagonal(int num)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            array[i, array.GetLength(0)-1-i] = num;
        }
    }

    public bool isRowSame(int rowNum)
    {
        bool isSame = true;
        for(int i=0;i<array.GetLength(0)-1;i++)
        {
            if (array[rowNum, i] != array[rowNum, i + 1])
                isSame = false;
        }
        return isSame;
 
    }
    public bool isColSame(int colNum)
    {
        bool isSame = true;
        for (int i = 0; i < array.GetLength(1) - 1; i++)
        {
            if (array[ i,colNum] != array[ i + 1, colNum])
                isSame = false;
        }
        return isSame;
    }

    public bool isDiagonalSame()
    {
        bool isSame = true;

        for (int i = 0; i < array.GetLength(0)-1; i++)
        {
            if (array[i, i] != array[i + 1, i + 1])
                isSame = false;
        }

        return isSame;
    }

    public bool isInverseDiagonalSame()
    {
        bool isSame = true;

        for (int i = 0; i < array.GetLength(0) - 1; i++)
        {
            
            if (array[i, (array.GetLength(0) - 1 - i)] != array[i + 1,( array.GetLength(0) - 2 - i)])
            {
                
                isSame = false;

            }

        }

        return isSame;
    }


    public void Print(int[,] array)
    {
        if (array != null)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Debug.Log(array[i, j]);
                }
            }
        }
        else
            Debug.Log("Array is null");

    }
    public int[,] Multiply(int[,] arr)
    {
        int[,] Arraytemp = new int[array.GetLength(0), array.GetLength(1)];
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int Col = 0; Col < array.GetLength(1); Col++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Arraytemp[row, Col] = Arraytemp[row, Col] + array[row, i] * arr[i, Col];
                }
            }
        }
        Print(Arraytemp);
        return Arraytemp;

    }
    public float[] GetRow(int rowNum)
    {
        float[] ans = new float[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(1); i++)
        {
            ans[i] = array[rowNum, i];
        }
      
        return ans;
    }

    public float[] GetCol(int colNum)
    {
        float[] ans = new float[array.GetLength(1)];
        for (int i = 0; i < array.GetLength(1); i++)
        {
            ans[i] = array[i,colNum];
        }
      
        return ans;
    }
    public float AddArrayMultiples(float[] arr, float[]arr1)
    {
        float ans = 0;
        for(int i = 0; i < arr.Length; i++) 
        {
            ans += (arr[i] * arr1[i]);
        }
        return ans;
    }

    public int Determinent2by2(int[,] Ary)
    {
        int determinentt;
        determinentt = (Ary[0, 0] * Ary[1, 1]) - (Ary[0, 1] * Ary[1, 0]);
        return determinentt;
    }
}
