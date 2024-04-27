using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("add 1 more chunck");
            ChunkList.instance.DequeueChunk();
            ChunkList.instance.EnqueueChunk();
        }
    }
}
