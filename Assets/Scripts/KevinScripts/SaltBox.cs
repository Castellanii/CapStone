using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBox : MonoBehaviour, IPickable
{
    [SerializeField] private float scaleMultiplier;

    private Vector3 currScale;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log($"Collided");
            
            DecreaseScale(scaleMultiplier);
            Destroy(this.gameObject);
        }
    }

    private void DecreaseScale(float scaleMultiplier)
    {
        //The player now have a different tag attached to it to avoid miss around with models
        Transform player = GameObject.FindGameObjectWithTag("PlayerMain").transform;

        Vector3 currScale = player.localScale;

        currScale -= new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);

        currScale = Vector3.Max(currScale, Vector3.zero);

        player.localScale = currScale;
    }
}
