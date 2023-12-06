using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
     {
        // Initialize the identity matrix
        entries[0, 0] = 1;
        entries[1, 1] = 1;
        entries[2, 2] = 1;
    }

    public HMatrix2D(float[,] multiArray)
    {      
        for (int y = 0; y < 3; y++) // create a row from 0 to less than 3
        {
                    for (int x = 0; x <  3; x++) // create a column from 0 to less than 3
           {
                entries[y, x] = multiArray[y, x];       
           }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

public static HMatrix2D operator +(HMatrix2D matrix1, HMatrix2D matrix2)
{
    HMatrix2D result = new HMatrix2D(); // Create the new matrix

    for (int row = 0; row < 3; row++)// go through the row
    {
        for (int col = 0; col < 3; col++)// go through the column
        {
            result.entries[row, col] = matrix1.entries[row, col] + matrix2.entries[row, col];// adding the numbers in the same spot of the matrix
        }
    }
    return result;
}


public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
{
    HMatrix2D result = new HMatrix2D();// Create the new matrix

    for (int y = 0; y < 3; y++)// go through the row
    {
        for (int x = 0; x < 3; x++)// go through the column
        {

            result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
        }
    }
    return result;
}


public static HMatrix2D operator *(HMatrix2D matrix, float scalar)
{
    HMatrix2D result = new HMatrix2D();// Create the new matrix

    for (int y = 0; y < 3; y++)// go through the row
    {
        for (int x = 0; x < 3; x++)// go through the column
        {
            result.entries[y, x] = matrix.entries[y, x] * scalar;
        }
    }
    return result;
}


    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        // Calculate the elements of the resulting vector using matrix-vector multiplication
        float resultX = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * 1.0f;
        float resultY = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * 1.0f;

        // Return the resulting vector
        return new HVector2D(resultX, resultY);
    }


    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // Iterate over each row and column
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                // Check if the corresponding elements are not equal
                if (left.entries[y, x] != right.entries[y, x])
                    return false; // If not equal, matrices are not equal

        // If all corresponding elements are equal, matrices are equal
        return true;
    }


public static bool operator !=(HMatrix2D left, HMatrix2D right)
{
    // Iterate over each row and column
    for (int y = 0; y < 3; y++)
        for (int x = 0; x < 3; x++)
            // Check if the corresponding elements are not equal
            if (left.entries[y, x] != right.entries[y, x])
                return true; // If not equal, matrices are not equal

    // If all corresponding elements are equal, matrices are equal
    return false;
}

    //public override bool Equals(object obj)
   // {
        // your code here
    //}

   // public override int GetHashCode()
    //{
        // your code here
    //}

    //public HMatrix2D transpose()
    //{
        //return // your code here
    //}

    //public float GetDeterminant()
    //{
        //return // your code here
    //}


//    public void setIdentity()
  //  {
    //    for (int y = 0; y < 3; y++) 
      //  {
        //    for (int x = 0; x < 3; x++) 
          //  {
            //    if(x == y)
               // {
                //    entries[y, x] = 1;
              //  }
            //    else
          //      {
        //            entries[y , x] = 0;
      //          }
    //        }
  //      }
//    }

    public void setIdentity()
    {
        for (int y = 0; y < 3; y++) 
        {
            for (int x = 0; x < 3; x++) 
            {
                entries[y, x] = (x == y) ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();
        entries[0, 2] = transX;
        entries[1, 2] = transX;
    }

   public void setRotationMat(float rotDeg)
   {
        setIdentity();

        float rad = rotDeg * Mathf.Deg2Rad;

        entries[0, 0] = Mathf.Cos(rad); 
        entries[0, 1] = -Mathf.Sin(rad); 
        entries[1, 0] = Mathf.Sin(rad); 
        entries[1, 1] = Mathf.Cos(rad);
   }

   // public void setScalingMat(float scaleX, float scaleY)
   // {
        // your code here
   // }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
