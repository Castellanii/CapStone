using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    //TODO: need to set scale Limit

    private float origGrowSpeed;
    private float acceleration;
    //private int divider = 100;
    private float currGrowSpeed;
    [SerializeField] private bool grow;

    public Vector3 originScale {get; private set;}
    private Vector3 currScale;

    // Start is called before the first frame update
    void Awake()
    {
        originScale = transform.localScale;
    }

    private void Start()
    {
        currGrowSpeed = origGrowSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grow)
        {
            if ((float)Math.Round(currGrowSpeed, 2) != (float)Math.Round(origGrowSpeed + acceleration * DifficultyManager.instance.RunningTime(), 2))
            
                Debug.Log("Player Grow Speed: " + currGrowSpeed.ToString("F2"));
            

            currGrowSpeed = origGrowSpeed + acceleration * DifficultyManager.instance.RunningTime();

            

            currScale = transform.localScale;
            currScale.x += currGrowSpeed * Time.deltaTime;
            currScale.y += currGrowSpeed * Time.deltaTime;
            currScale.z += currGrowSpeed * Time.deltaTime;

            transform.localScale = currScale;
        }
        
    }

    public void Initialize(float _growSpeed, float _acceleration)
    {
        origGrowSpeed = _growSpeed;
        acceleration = _acceleration;
    }


}
