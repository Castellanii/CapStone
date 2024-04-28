using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ChunkList : MonoBehaviour
{
    [SerializeField] private float chunkLength = 10f;

    [SerializeField] private GameObject ChunkPrefab;
    private Queue<GameObject> Chunk = new Queue<GameObject>();
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
    }

    // Start is called before the first frame update
    void Start()
    {

        Vector3 tempPos = Vector3.zero;

        //put all chunks in queue
        for (int i = 0; i < 5; i++)
        {
            
            tempPos.z = i * chunkLength;
            Debug.Log(tempPos);

            Transform newChunk = GenerateNewChunk(tempPos);
            if (i == 4)
            {
                lastChunk = newChunk.transform;
            }

        }
    }


    public void DequeueChunk()
    {
        Destroy(Chunk.Dequeue());

    }

    public void EnqueueChunk()
    {
        Vector3 newPos = new Vector3(0, 0, lastChunk.localPosition.z + chunkLength);

        lastChunk = GenerateNewChunk(newPos).transform;


    }

    private Transform GenerateNewChunk(Vector3 newPos)
    {
        GameObject newChunk = Instantiate(ChunkPrefab, this.transform);
        newChunk.transform.localPosition = newPos;

        //newChunk.GetComponent<Chunk>().GenerateFood();
        newChunk.GetComponent<Chunk>().GenerateCoinPrefabGroup();
        

        Chunk.Enqueue(newChunk);
        return newChunk.transform;
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
