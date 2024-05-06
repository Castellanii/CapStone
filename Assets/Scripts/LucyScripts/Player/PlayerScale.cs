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
    [SerializeField] private float maxGrowSpeed = 0.5f;
    [SerializeField] private float HighestScale = 8.0f;

    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private GameObject explosion;

    public Vector3 originScale {get; private set;}
    public float highestScale { get; private set; }
    private Vector3 currScale;

    private bool pause;

    // Start is called before the first frame update
    void Awake()
    {
        originScale = transform.localScale;
        highestScale = HighestScale;
        explosion.SetActive(false);
        explosionEffect.Stop();
    }

    private void Start()
    {
        currGrowSpeed = origGrowSpeed;
        

    }

    public Vector3 GetCurrScale()
    {
        return currScale;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (pause) return;
        if (grow)
        {
            //Debug lines
            if ((float)Math.Round(currGrowSpeed, 2) != (float)Math.Round(origGrowSpeed + acceleration * DifficultyManager.instance.RunningTime(), 2))
            
                //Debug.Log("Player Grow Speed: " + currGrowSpeed.ToString("F2"));

            if (currGrowSpeed != maxGrowSpeed)
            currGrowSpeed = origGrowSpeed + acceleration * DifficultyManager.instance.RunningTime();
                currGrowSpeed = currGrowSpeed >= maxGrowSpeed?maxGrowSpeed: currGrowSpeed;

            currScale = transform.localScale;
            currScale.x += currGrowSpeed * Time.deltaTime;
            currScale.y += currGrowSpeed * Time.deltaTime;
            currScale.z += currGrowSpeed * Time.deltaTime;

            transform.localScale = currScale;
        }



        //Check Die condition
        if (currScale.x >= highestScale && LivesCounter.Instance.CurrLives() > 0)
        {
            pause = true;
            explosion.SetActive(true);
            explosionEffect.Play();
            
            LivesCounter.Instance.LoseLife(0, explosionEffect.main.duration + 0.3f);
            
        }
        
    }

    public void Initialize(float _growSpeed, float _acceleration)
    {
        origGrowSpeed = _growSpeed;
        acceleration = _acceleration;
    }


}
