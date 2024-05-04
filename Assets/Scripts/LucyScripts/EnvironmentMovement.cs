using UnityEngine;
using System;

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField] private float initMoveSpeed;//5
    [SerializeField] private float moveAcceleration;//0.017
    [SerializeField] private float maxMoveSpeed;//10

    private float currMoveSpeed;


    private void Start()
    {
        currMoveSpeed = initMoveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug
        if ((float)Math.Round(currMoveSpeed, 2) != (float)Math.Round((initMoveSpeed + DifficultyManager.instance.RunningTime() * moveAcceleration), 2))
            //Debug.Log("chunkMoveSpeed: " + (currMoveSpeed).ToString("F2"));

            //Update currSpeed
            currMoveSpeed = initMoveSpeed + DifficultyManager.instance.RunningTime() * moveAcceleration;
        
        if (currMoveSpeed > maxMoveSpeed)
        {
            currMoveSpeed = maxMoveSpeed;
        }

            transform.Translate(Vector3.right * currMoveSpeed * Time.deltaTime);
    }


    




}

 
       

    