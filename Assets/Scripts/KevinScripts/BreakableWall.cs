using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public Hamburger hamburger;
    private Animator wallAnimation;
    private void Awake()
    {
        wallAnimation = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hamburger.canBreak)
        {
            Debug.Log($"Wall is breaking");
            wallAnimation.SetTrigger("Breaking");
            Destroy(this.gameObject, 5.0f);
        }
    }
}
