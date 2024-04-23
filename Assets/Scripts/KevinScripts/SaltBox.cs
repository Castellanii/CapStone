using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBox : MonoBehaviour, IPickable
{
    [SerializeField] GameObject player;
    [SerializeField] private float scaleMultiplier;

    private Vector3 currScale;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Collided");
            DecreaseScale(scaleMultiplier);
        }
    }

    private void DecreaseScale(float scaleMultiplier)
    {
        Vector3 currScale = player.transform.localScale;

        currScale -= new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);

        currScale = Vector3.Max(currScale, Vector3.zero);

        player.transform.localScale = currScale;
    }
}
