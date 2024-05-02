using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObstacles : MonoBehaviour
{
    [SerializeField] private List<GameObject> Obstacles;


    public void GenerateObstacles(float possibility)
    {
        bool activate;
        for (int i = 0; i < Obstacles.Count; i++)
        {
            activate = Random.Range(0f, 1f) <= possibility ? true : false;
            if (activate)
            {
                Obstacles[i].SetActive(true);
            }
            
        }
    }

}
