using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IPickable
{
    [SerializeField] private Material breakMaterial;
    //[SerializeField] private Material origMaterial;

    [SerializeField] private float materialDuration;
    //private Renderer renderer;

    //the hamburger will be destroyed. the status should store in player
    //[SerializeField] private bool canBreak = false;

    private PlayerCondition playerCondition;

    private void Awake()
    {
        playerCondition = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<PlayerCondition>();
    }
    void Start()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//other is the current player model, not the renderer
        {

            //renderer.material = breakMaterial;

            //playerCondition.SetBreakable(true, materialDuration);

            //Invoke("RevertMaterial", materialDuration);

            playerCondition.HitHamburgerPickUp(breakMaterial, materialDuration);
            Destroy(this.gameObject);
        }
    }
    //The hamburger will be destroyed at the same time when the chunck destroyed
    //Revert doesn't work here
    //Also the hamburger should be triggered by pressing burger UI
    //Gonna write inside playerCondition script instead


    //private void RevertMaterial()
    //{
    //    renderer = playerCondition.playerRendererDic[playerCondition.currShape];
    //    renderer.material = origMaterial;
    //    playerCondition.SetBreakable(false);
    //}


}
