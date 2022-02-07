using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Matrix 
{
    List<List<int>> matrixx;
    List<int> listt;
    public void MatrixUsingLists(int row, int col)
    {
        matrixx = new List<List<int>>();

        for (int i = 0; i < row; i++)
        {
            listt = new List<int>();

            for (int j = 0; j < col; j++)
            {
                listt.Add(0);
            }
            matrixx.Add(listt);
        }
    }
}
