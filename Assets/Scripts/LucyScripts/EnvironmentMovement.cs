using UnityEngine;
using System.Collections;

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }


}

 
       

    