using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{

    [SerializeField] private float imageWidth = 70f;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int numOfLives = 3;

    private RectTransform rect;

    public Action OnDeath;
    public Action OnDamage;

    public static LivesCounter Instance;

    void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public int NumofLives
    {
        get => numOfLives;
        private set
        {
            numOfLives = Mathf.Clamp(value, 0, maxLives);
            if (value <= 0)
            {
                OnDeath();
            }
            
            AdjustImageWidth();
        }
    }

    private void Awake()
    {
        Singleton();
        rect = transform as RectTransform;
        AdjustImageWidth();
    }

    public void LoseLife()
    {
        NumofLives -= 1;

        if (NumofLives > 0)
        {
            OnDamage?.Invoke();
        }

    }
    public void LoseLife(int _NumofLives)
    {
        NumofLives = _NumofLives;
    }

    private void AdjustImageWidth()
    {
        rect.sizeDelta = new Vector2(imageWidth * numOfLives, rect.sizeDelta.y);
    }
}
