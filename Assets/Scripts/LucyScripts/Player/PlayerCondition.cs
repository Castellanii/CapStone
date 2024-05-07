using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//Todo: make this script singleton, so hamburger can find it easier
public class PlayerCondition : MonoBehaviour
{
    
    [Header("Sponge, Patrick, Gary")]
    [SerializeField] private Renderer[] playerRenderer;

    public Dictionary<Shape, Renderer> playerRendererDic { get; private set; }
    public Shape currShape { get; private set; }

    private ShapeShiftInteractor shapeShiftInteractor;


    //For Hamburger
    public bool canBreak { get; private set; }

    //Following line Limit only 1 breakable wall in the scene, because player only can have 1 hamburger
    public bool Exhausted { get;  set; }

    private bool isRunning = false;
    private Coroutine revertMaterial;

    private Shape poweredShape;
    private Material[] origMaterials;
    private Material breakMaterial;
    private float timeDuration;
    public Action EnableHamburgerUI;
    public Action UpdateCurrMaterial;
    private void OnEnable()
    {
        shapeShiftInteractor.ShapeChanged += UpdateCurrShape;
    }

    private void Awake()
    {
        shapeShiftInteractor = GetComponent<ShapeShiftInteractor>();
        playerRendererDic = new Dictionary<Shape, Renderer>();
    }

    private void Start()
    {
        currShape = Shape.Sponge;
        canBreak = false;


        playerRendererDic.Add(Shape.Sponge, playerRenderer[0]);
        playerRendererDic.Add(Shape.Patrick, playerRenderer[1]);
        playerRendererDic.Add(Shape.Gary, playerRenderer[2]);

        
    }

    public Renderer GetPlayerRenderer()
    {
        return playerRendererDic[currShape];
    }

    private void UpdateCurrShape(Shape _currShape)
    {
        if (currShape == _currShape) { return; }
        Debug.Log($"update curr shape to {_currShape.ToString()}");

        if (canBreak)
        {
            playerRendererDic[poweredShape].materials = origMaterials;
            currShape = _currShape;
            UpdateHamburgerVar();
        }
        
        currShape = _currShape;
        //Order can't change for the following
        UpdateCurrMaterial?.Invoke();

    }

    //For hamburger usage
    

    public void HitHamburgerPickUp(Material _breakMaterial, float _timeDuration)
    {
        //active Hamburger UI
        EnableHamburgerUI?.Invoke();
        breakMaterial = _breakMaterial;
        timeDuration = _timeDuration;

        
    }

    public void ActivateHamburgerMode()
    {


        if (!isRunning)
        {
            UpdateHamburgerVar();
            AudioManager.instance.PlayAudioForDuration(AudioManager.instance.sources[1], 0.6f);
            SetBreakable(true);
            revertMaterial = StartCoroutine(RevertMaterial(timeDuration));
            //Invoke("RevertMaterial", timeDuration);   
        }
        else
        {
            StopCoroutine(revertMaterial);
            revertMaterial = StartCoroutine(RevertMaterial(timeDuration));
        }

    }

    private void UpdateHamburgerVar()
    {
        poweredShape = currShape;
        origMaterials = playerRendererDic[poweredShape].materials;

        //Solve for multiple materials case
        int value = playerRendererDic[poweredShape].materials.Length;
        Material[] newMat = new Material[value];
        for (int i = 0; i < value; i++)
        {
            newMat[i] = breakMaterial;
        }
         
        playerRendererDic[poweredShape].materials = newMat;
    }

    private void SetBreakable(bool _breakable)
    {
        canBreak = _breakable;
    }

    IEnumerator RevertMaterial(float timeDuration)
    {
        isRunning = true;
        yield return new WaitForSeconds(timeDuration);
        
        isRunning = false;
        //Debug.Log("revertMaterial");
        playerRendererDic[poweredShape].materials = origMaterials;
        SetBreakable(false);

       
    }
}
