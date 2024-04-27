using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public Hamburger hamburger;
    private Animator wallAnimation;
    [SerializeField] private Collider wallCollider;
    private void Awake()
    {
        wallAnimation = GetComponent<Animator>();
        wallCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))// && hamburger.canBreak)
        {
            Debug.Log($"Wall is breaking");
            wallAnimation.SetTrigger("Breaking");
            wallCollider.enabled = false;
            Destroy(this.gameObject, 2.0f);
        }
    }
}
