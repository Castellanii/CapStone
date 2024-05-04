using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarPointer : MonoBehaviour
{
    //Cursor position range
    [SerializeField] private float LowPointY;
    [SerializeField] private float HighPointY;
    [SerializeField] private float timeDuration = 0.5f;

    [SerializeField] private PlayerScale playerScale;


    private float highestScale;
    private float lowestScale;
    private float rangeScale;

    private float currPointY;
    private Vector3 currVector;
    private void Start()
    {
        lowestScale = playerScale.originScale.x;
        highestScale = playerScale.highestScale;
        rangeScale = highestScale - lowestScale;

        currVector.x = this.transform.localPosition.x;
        currVector.z = this.transform.localPosition.z;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log($"({playerScale.GetCurrScale().x - lowestScale} / {rangeScale}) *  ({HighPointY} - {LowPointY})+ {LowPointY}");
        currPointY = ((playerScale.GetCurrScale().x-lowestScale) / rangeScale) *
            (HighPointY - LowPointY) + LowPointY;
       // Debug.Log($"result: {currPointY}");
        
        
        currVector.y = currPointY;
        this.transform.localPosition = currVector;
    }
}
