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
            Destroy(other.gameObject);
            player.SetActive(false);
            gary.SetActive(true);
            Invoke("RevertTransformation", transformDuration);
        }

        if (other.gameObject.tag.Equals("Patrick"))
        {
            Debug.Log($"Collided");
            Destroy(other.gameObject);
            player.SetActive(false);
            patrick.SetActive(true);
            Invoke("RevertTransformation", transformDuration);

        }
    }
    void RevertTransformation()
    {
        patrick.SetActive(false);
        gary.SetActive(false);
        player.SetActive(true);
    }

}