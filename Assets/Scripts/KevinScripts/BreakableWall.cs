using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private Animator wallAnimation;
    [SerializeField] private Collider wallCollider;
    private PlayerCondition playerCondition;
    

    private void Awake()
    {
        wallAnimation = GetComponent<Animator>();
        wallCollider = GetComponent<Collider>();
        playerCondition = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<PlayerCondition>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            playerCondition.Exhausted = false;

            //Debug.Log("breakable: " + playerCondition.canBreak);
            if (playerCondition.canBreak)
            {
                Debug.Log($"Wall is breaking");
                wallAnimation.SetTrigger("Breaking");
                wallCollider.enabled = false;
                Destroy(this.gameObject, 2.0f);
            }
            else
            {
                Debug.Log("Player is damaged by the breaking wall");
                LivesCounter.Instance.LoseLife();
                Destroy(this.gameObject);
            }
            
        }
    }
}
