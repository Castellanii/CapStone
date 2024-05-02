using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private LivesCounter playerLives;
    // Start is called before the first frame update

    private void Awake()
    {
        playerLives = GameObject.FindObjectOfType<LivesCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("obstacle(tree) hit the player");
            playerLives.LoseLife();
        }
    }
}
