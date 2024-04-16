using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    //public Action<int> OnScoreUpdated;
    [SerializeField] public int coinValue;
    public int score {get; private set; }


    private float gamingTime;

    public static ScoreManager instance;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //OnScoreUpdated?.Invoke(score);
        UIManager.instance.UpdateScoreUI(score);
        gamingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gamingTime += Time.deltaTime;

        if (score != (int)Mathf.Floor(gamingTime))
        {
            score = (int)Mathf.Floor(gamingTime);
            //Debug.Log(score);
            UIManager.instance.UpdateScoreUI(score);
            //OnScoreUpdated?.Invoke(score);
        }
        
    }

    public void CoinToScore()
    {
        score += coinValue;
        UIManager.instance.UpdateScoreUI(score);
    }
}
