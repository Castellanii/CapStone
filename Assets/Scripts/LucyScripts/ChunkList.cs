using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChunkList : MonoBehaviour
{
    [SerializeField] private GameObject[] chunckList;
    [SerializeField] private float chunkLength = 10f;
    private Queue<GameObject> Chunk = new Queue<GameObject>();
    private Queue<GameObject> dequeueChunk = new Queue<GameObject>();
    private int enqIndex = -1;

    private Transform lastChunk;

    public static ChunkList instance;

    void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance = this;
    }

    private void Awake()
    {
        Singleton();
        lastChunk = chunckList[chunckList.Length - 1].transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //put all chunks in queue
        for (int i = 0; i < chunckList.Length; i++)
        {
            Chunk.Enqueue(chunckList[i]);
        }
    }


    public void DequeueChunk()
    {
        GameObject old = Chunk.Dequeue();   
        GameObject newitem = Instantiate(old);
        dequeueChunk.Enqueue(newitem);
        Destroy(old);
    }

    public void EnqueueChunk()
    {
        Vector3 newPos = new Vector3(lastChunk.position.x, lastChunk.position.y, lastChunk.position.z+chunkLength);
        GameObject newitem = dequeueChunk.Dequeue();
        //Debug.Log(newitem.transform.position);
        newitem.transform.position = newPos;
        newitem.transform.parent = this.transform;
        Chunk.Enqueue(newitem);
        lastChunk = newitem.transform;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
