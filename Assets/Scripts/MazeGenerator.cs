using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int depth;
    private string[,] laby;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    string[,] CreateArray(int widthArr, int depthArray)
    {
        string[,] arr = new string[width, depth];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                arr[i, j] = "*";
            }
        }
        return arr;
    }


}
