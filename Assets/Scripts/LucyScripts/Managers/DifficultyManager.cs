using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class DifficultyManager : MonoBehaviour
{
    [Header("Variables")]
    [Range(0.005f, 0.05f)]
    [SerializeField] private float playerGrowSpeed;//0.005
    [Range(0.005f, 0.01f)]
    [SerializeField] private float playerGrowAcceleration;//0.005

    [SerializeField] private float chunkMoveSpeed = 5;//5
    [SerializeField] private float chunkmoveSpeedAcceleration = 0.01f;//0.01


    [Header("Scripts")]
    [SerializeField] private PlayerScale playerScale;
    [SerializeField] private EnvironmentMovement environmentMovement;

    float runningTime = 0;
    //public Action<float> chunkSpeedChange;
    public static DifficultyManager instance;

    void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance = this;
    }

    private void Awake()
    {
        Singleton();
        playerScale.Initialize(playerGrowSpeed, playerGrowAcceleration);
        
        //chunkSpeedChange?.Invoke(chunkMoveSpeed);
    }

    void Update()
    {
        runningTime += Time.deltaTime;
    }

    public float RunningTime()
    {
        return runningTime;
    }

    

    
}
