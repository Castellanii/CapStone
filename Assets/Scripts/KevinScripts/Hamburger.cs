using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IPickable
{
    [SerializeField] private Material breakMaterial;
    [SerializeField] private Material origMaterial;

    [SerializeField] private GameObject player;
    [SerializeField] private float materialDuration;
    private Renderer renderer;

    [SerializeField] private bool canBreak = false;

    void Start()
    {
        renderer = player.GetComponent<Renderer>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material = breakMaterial;
            canBreak = true;
            Invoke("RevertMaterial", materialDuration);
        }
    }

    private void RevertMaterial()
    {
        renderer.material = origMaterial;
        canBreak = false;
    }


}
