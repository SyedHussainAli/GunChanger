using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrixs : MonoBehaviour
{
    int[,] array2D = new int[2, 2] { { 1, 2 }, { 4, 5 } };
    int[] arr = { 9, 8 };

    // Start is called before the first frame update
    void Start()
    {
      //  MatrixUsingArrays mat = new MatrixUsingArrays(array2D);

        MatrixUsingArrays matrixxx = new MatrixUsingArrays(array2D);
        matrixxx.Print();
       // matrixxx.SetDiagonal(5);
        matrixxx.Multiply(array2D);

        //Debug.Log(matrixxx.isInverseDiagonalSame());
       
        /*
        matrixxx.Print();*/

        /*  matrixxx.SetElement(1, 1, 6);
          matrixxx.Print();*/
        // Debug.Log("Value of element is:"+matrixxx.GetElement(1,1));
        //  matrixxx.SetCol(0, arr);
        //matrixxx.Print();
        /*  matrixxx.Add(array2D);
          matrixxx.Print();
          matrixxx.Add(array2D);
          matrixxx.Add(array2D);
          matrixxx.Print();
          matrixxx.Subtract(array2D);
          matrixxx.Print();*/

    }

}
