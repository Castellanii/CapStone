using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShiftInteractor : MonoBehaviour
{
    [SerializeField] private GameObject gary;
    [SerializeField] private GameObject patrick;
    [SerializeField] private GameObject player;
    [SerializeField] private float transformDuration = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Gary"))
        {
            Debug.Log($"Collided");
            //Destroy(other.gameObject);
            gary.SetActive(true);
            player.SetActive(false);
            patrick.SetActive(false);
            Invoke("RevertTransformation", transformDuration);
        }

        if (other.gameObject.tag.Equals("Patrick"))
        {
            Debug.Log($"Collided");
            //Destroy(other.gameObject);
            patrick.SetActive(true);
            player.SetActive(false);
            gary.SetActive(false);
            Invoke("RevertTransformation", transformDuration);

        }
    }
    void RevertTransformation()
    {
        player.SetActive(true);
        patrick.SetActive(false);
        gary.SetActive(false);
        
    }

}