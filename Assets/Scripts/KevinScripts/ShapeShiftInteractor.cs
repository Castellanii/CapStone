using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public enum Shape
{
    Sponge, Patrick, Gary
}

public class ShapeShiftInteractor : MonoBehaviour
{
    [SerializeField] private GameObject gary;
    [SerializeField] private GameObject patrick;
    [SerializeField] private GameObject player;
    [SerializeField] private float transformDuration;

    public Shape playerShape { get; private set; } 

    public Action<Shape> ShapeChanged;


    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Gary"))
        {
            //Debug.Log($"Collided");
            Destroy(other.gameObject);
            gary.SetActive(true);
            player.SetActive(false);
            patrick.SetActive(false);

            ShapeChanged(Shape.Gary);
            playerShape = Shape.Gary;
            Invoke("RevertTransformation", transformDuration);
        }

        if (other.gameObject.tag.Equals("Patrick"))
        {
            //Debug.Log($"Collided");
            Destroy(other.gameObject);
            patrick.SetActive(true);
            player.SetActive(false);
            gary.SetActive(false);

            ShapeChanged(Shape.Patrick);
            playerShape = Shape.Patrick;
            Invoke("RevertTransformation", transformDuration);

        }
    }
    void RevertTransformation()
    {
        player.SetActive(true);
        patrick.SetActive(false);
        gary.SetActive(false);

        ShapeChanged(Shape.Sponge);
        playerShape = Shape.Sponge;

    }

}