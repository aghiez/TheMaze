using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratt : MonoBehaviour
{
 public int width = 20;
    public int height = 20;
    public int iterations = 100;

    private bool[,] grid;

    void Start()
    {
        grid = new bool[width, height];

        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        grid[y, x] = true;

        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        for (int i = 0; i < iterations; i++)
        {
            int newX = x + dx[Random.Range(0, 4)];
            int newY = y + dy[Random.Range(0, 4)];

            if (newX >= 0 && newX < width && newY >= 0 && newY < height)
            {
                x = newX;
                y = newY;
                grid[y, x] = true;
            }

            string output = "";
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < width; k++)
                {
                    output += grid[j, k] ? "#" : " ";
                }
                output += "\n";
            }
            Debug.Log(output);

            System.Threading.Thread.Sleep(100);
        }
    }
}
