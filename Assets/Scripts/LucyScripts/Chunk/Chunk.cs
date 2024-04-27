using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    //inside item list, the position of the group
    //a: z= -0.7
    //b: z= 0.0
    //c: z = 0.8

    //e: x: -0.7

    [SerializeField] private Transform CoinPrefabList;
    [SerializeField] private Transform FoodList;

    [SerializeField] private float SaltPossibility = 0.7f;

    [SerializeField] private float ObstaclePossibility = 0.5f;

    private int PrefabCount;

    private float[] lanePositionList;
    private float[] foodPositionList;


    private int laneNum;
    private int prefabNum;

    
    public void GenerateCoinPrefabGroup()
    {
        laneNum = Random.Range(0, 3);
        
        prefabNum = Random.Range(0, PrefabCount);
        //Debug.Log($"laneNum: {laneNum}, prefabNum: {prefabNum}");


        //update position of specific prefab
        Vector3 tempPos = CoinPrefabList.GetChild(prefabNum).position;
        tempPos = new Vector3(0, 0, lanePositionList[laneNum]);
        CoinPrefabList.GetChild(prefabNum).localPosition = tempPos;

        //enable that prefab group with updated position
        CoinPrefabList.GetChild(prefabNum).gameObject.SetActive(true);
        CoinPrefabList.GetChild(prefabNum).GetComponent<CoinGroup>().GenerateObstacles(ObstaclePossibility);

    }

    public void GenerateFood()
    {
        //z = -0.2 | 0.5 | 1.2
        bool isSalt = Random.Range(0f, 1f) <= 0.8f ? true: false;
        if (isSalt)
        {

            Vector3 temp = FoodList.GetChild(1).localPosition;
            temp.z = foodPositionList[Random.Range(0, 3)];
            FoodList.GetChild(1).localPosition = temp;

            FoodList.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Vector3 temp = FoodList.GetChild(0).localPosition;
            temp.z = foodPositionList[Random.Range(0, 3)];
            FoodList.GetChild(0).localPosition = temp;

            FoodList.GetChild(0).gameObject.SetActive(true);
        }


    }


    private void Awake()
    {
        InitialLanePositionList();
        InitialFoodPositionList();

        PrefabCount = CoinPrefabList.childCount;
    }

    
    private void InitialFoodPositionList()
    {
        foodPositionList = new float[3];
        foodPositionList[0] = -0.2f;
        foodPositionList[1] = 0.5f;
        foodPositionList[2] = 1.2f;
    }

    private void InitialLanePositionList()
    {
        lanePositionList = new float[3];
        lanePositionList[0] = -0.7f;
        lanePositionList[1] = 0f;
        lanePositionList[2] = 0.8f;
    }

}
