using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public enum PrefabList
{
    CoinPrefab,
    BreakWallPrefab,
    ShapePrefab
};
public class Chunk : MonoBehaviour
{
    //inside item list, the position of the group
    //a: z= -0.7
    //b: z= 0.0
    //c: z = 0.8

    //e: x: -0.7

    [Header("Prefab")]
    [SerializeField] private Transform FoodList;
    [SerializeField] private Transform CoinPrefabList;
    [SerializeField] private Transform BreakWallPrefab;
    [SerializeField] private Transform ShapeWallPrefab;
    

    [Header("Possibility")]
    [SerializeField] private float SaltPossibility;
    [SerializeField] private float ObstacleInCoinPossibility;
    [Header("Coin, Breakable, Shape (int)")]
    [SerializeField] List<int> PrefabPossibilityInput;


   
    private List<int> PrefabPossibility;
    private int PrefabCount;

    private float[] lanePositionList;
    private float[] foodPositionList;


    private int laneNum;
    private int prefabNum;


    private PlayerCondition playerCondition;

    public void GeneratePrefabGroup()
    {
        //0: coin, 1: breakable, 2:shapeWall
        if (!this.GetComponentInParent<ChunkList>().HamburgerSpawned()
            ||playerCondition.Exhausted)
        {
            PrefabPossibility[1] = 0;
            //Debug.Log("hamburger not spawned");
        }
        else
        {
            PrefabPossibility[1] = PrefabPossibilityInput[1];
        }

        int rand = Random.Range(0, PrefabPossibility.Sum());
        //Debug.Log($"current rand: {rand}");
        if (rand < PrefabPossibility[0])
        {
            //Generate Coin
            //Debug.Log("Generate Coin");
            GenerateCoinPrefabGroup();
        }
        else if (rand < PrefabPossibility[0] + PrefabPossibility[1])
        {
            playerCondition.Exhausted = true;
            //Generate Breakable wall
            //Debug.Log("Generate Breakable wall");
            GenerateBreakablePrefabGroup();
        }
        else
        {
            //Generate Shape wall
            //Debug.Log("Generate Shape wall");
            GenerateShapePrefabGroup();
        }

    }

    public void GenerateShapePrefabGroup()
    {
        ShapeWallPrefab.gameObject.SetActive(true);
        ShapeWallPrefab.GetComponent<ShapeShiftWallprefabGroup>().GenerateShapeShiftWallprefabGroup(lanePositionList);
    }

    public void GenerateBreakablePrefabGroup()
    {
        BreakWallPrefab.gameObject.SetActive(true);
    }
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
        //CoinPrefabList.GetChild(prefabNum).GetComponent<CoinObstacles>().GenerateObstacles(ObstacleInCoinPossibility);
        CoinPrefabList.GetChild(prefabNum).GetComponent<CoinObstacles>().GenerateObstacles();
    }

    public void GenerateFood()
    {
        //z = -0.2 | 0.5 | 1.2
        bool isSalt = Random.Range(0f, 1f) <= SaltPossibility ? true: false;
        if (isSalt)
        {

            Vector3 temp = FoodList.GetChild(1).localPosition;
            temp.z = foodPositionList[Random.Range(0, 3)];
            FoodList.GetChild(1).localPosition = temp;

            FoodList.GetChild(1).gameObject.SetActive(true);
        }
        else//Hamburger
        {
            Vector3 temp = FoodList.GetChild(0).localPosition;
            temp.z = foodPositionList[Random.Range(0, 3)];
            FoodList.GetChild(0).localPosition = temp;

            FoodList.GetChild(0).gameObject.SetActive(true);
            this.GetComponentInParent<ChunkList>().HamburgerSpawned(true);
        }


    }


    private void Awake()
    {
        InitialLanePositionList();
        InitialFoodPositionList();

        PrefabCount = CoinPrefabList.childCount;
        playerCondition = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<PlayerCondition>();

        PrefabPossibility = new List<int>(PrefabPossibilityInput);

    }

    private void Start()
    {
        
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
