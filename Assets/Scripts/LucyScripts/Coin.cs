
using System;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private Transform coinTransform;


    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private int coinValue = 10;

    //can't use action because the coin is not prefab. instantiate
    //public Action<int> coinUpdated;


    private void Awake()
    {
        coinTransform = GetComponent<Transform>(); 
    }
    // Update is called once per frame
    void Update()
    {
        coinTransform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("collect coin");
            //coinUpdated?.Invoke(coinValue);
            ScoreManager.instance.AddScore(coinValue);
            AudioManager.instance.PlayCollectCoinAudio();


            Destroy(this.gameObject);

        }
    }
}
