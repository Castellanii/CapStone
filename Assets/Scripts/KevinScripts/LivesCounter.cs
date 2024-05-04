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

    private void AdjustImageWidth()
    {
        rect.sizeDelta = new Vector2(imageWidth * numOfLives, rect.sizeDelta.y);
    }
}
