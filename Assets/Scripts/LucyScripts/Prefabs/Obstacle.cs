using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(4);
            Debug.Log("obstacle(tree) hit the player");
            LivesCounter.Instance.LoseLife();
            Destroy(this.gameObject);
        }
    }
}
