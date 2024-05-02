using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    //TODO: need to set scale Limit

    [SerializeField] private float growSpeed;
    [SerializeField] private bool grow;

    private Vector3 originScale;
    private Vector3 currScale;

    // Start is called before the first frame update
    void Start()
    {
        originScale = transform.localScale;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (grow)
        {
            currScale = transform.localScale;
            currScale.x += growSpeed * Time.deltaTime;
            currScale.y += growSpeed * Time.deltaTime;
            currScale.z += growSpeed * Time.deltaTime;

            transform.localScale = currScale;
        }
        
    }
    
}
