using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int score {get; private set; }


    private float scoreFloat;

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
        scoreFloat = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreFloat += Time.deltaTime;

        if (score != (int)Mathf.Floor(scoreFloat))
        {
            score = (int)Mathf.Floor(scoreFloat);
            //Debug.Log(score);
            UIManager.instance.UpdateScoreUI(score);
            //OnScoreUpdated?.Invoke(score);
        }
        
    }

    public void AddScore(int addValue)
    {
        //Debug.Log("the score is added");
        scoreFloat += addValue;  
    }

}
