using System;
using System.Collections;
using UnityEngine;

public class Utility : MonoBehaviour {


    public static int gridRows;
    public static int gridCols;
    public static float offsetX;
    public static float offsetY;

    public static ArrayList numbers;
    public static ArrayList used = new ArrayList();

    public static int totalCards;
    public static int cardsSoFar = 0;
    public static Vector3 startingPos;
    public static Vector3 startingScale = new Vector3(1, 1, 1);

    public static ArrayList GetNewNumbers(int size) 
    {
        ArrayList numbers = new ArrayList();

        System.Random random = new System.Random();

        while (size > 0)
        {
            int temp = random.Next(52);

            if (used.Contains(temp) || numbers.Contains(temp))
            {
                continue;
            }
            else
            {
                numbers.Add(temp);
                numbers.Add(temp);
                size--;
            }
        }
        return numbers;
    }
}
