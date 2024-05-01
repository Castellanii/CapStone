using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinObstacles : MonoBehaviour
{
    [SerializeField] private List<GameObject> Obstacles;
    [SerializeField] private float origPossibility; // 0.4
    [SerializeField] private float acceleration; // 0.01


    private float currPossibility;

    private bool isActive;

    public void GenerateObstacles()
    {
        if (currPossibility == 1) 
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Obstacles[i].SetActive(true);
            }
            return;
        }

        //if ((float)Math.Round(currPossibility, 2) != (float)Math.Round((origPossibility + acceleration * DifficultyManager.instance.RunningTime()), 2))
            

        currPossibility = origPossibility + acceleration * DifficultyManager.instance.RunningTime();
        Debug.Log("coinObstacle possibility: " + currPossibility.ToString("F2"));

        for (int i = 0; i < Obstacles.Count; i++)
        {
            isActive = UnityEngine.Random.Range(0f, 1f) <= currPossibility ? true : false;

            if (isActive)
            {
                Obstacles[i].SetActive(true);
            }
            
        }
    }


}
