using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Shader worldCurve;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null )
        {
            mainCamera.RenderWithShader(worldCurve, "RenderType");
        }
        
    }
}
