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
            
            DecreaseScale();
            Destroy(this.gameObject);
        }
    }

    private void DecreaseScale()
    {
        //The player now have a different tag attached to it to avoid miss around with models
        Transform player = GameObject.FindGameObjectWithTag("PlayerMain").transform;

        Vector3 currScale = player.localScale;

        currScale *= (1 - scaleMultiplier);

        //Ensure the size is not smaller than the origin scale
        currScale = Vector3.Max(currScale, player.GetComponent<PlayerScale>().originScale);
        
        player.localScale = currScale;
    }

    public void setScaleMultiplier(float _scaleMultiplier)
    {
        scaleMultiplier = _scaleMultiplier;
    }
}
