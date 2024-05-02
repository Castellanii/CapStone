using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShiftWall : MonoBehaviour
{
    //[SerializeField] private Collider shapeShiftCollider;
    [SerializeField] private Collider wallCollider;

    private void Awake()
    {
        wallCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    if (other.transform.GetComponent<ShapeShiftInteractor>().playerShape)
        //    {
        //        //ToDo pass through wall
        //        Debug.Log($"You passed through the wall");
        //    } 
        //}
        //else
        //{
        //    //ToDo Lose Life
        //    Debug.Log($"You hit the wall");
        //}
    }



}
