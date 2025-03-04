using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveChanger : MonoBehaviour
{
    public Material[] myMaterials;
    [SerializeField] private float targetValue;
    [SerializeField] private float currentValue;
    [SerializeField] private float lerpTime;
    [SerializeField] private float backwardsTarget;
    [SerializeField] private float backwardsCurrent;

    private bool isComplete = true;


    private void Start()
    {
        foreach (Material material in myMaterials)
        {
            currentValue = material.GetFloat("_Sideways_Curve");
            backwardsCurrent = material.GetFloat("_Backwards_Curve");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Curve"))
        {
            if (isComplete)
            {
                StartCoroutine(ChangeCurveStrength());
            }
            
        }
    }

    public IEnumerator ChangeCurveStrength()
    {
        float elaspedTime = 0;
        targetValue = Random.Range(-0.005f, 0.005f);
        backwardsTarget = Random.Range(-0.0005f, 0.0005f);

        while (elaspedTime < lerpTime)
        {
            isComplete = false;
            currentValue = Mathf.Lerp(currentValue, targetValue, elaspedTime / lerpTime);
            backwardsCurrent = Mathf.Lerp(backwardsCurrent, backwardsTarget, elaspedTime / lerpTime);
            elaspedTime += Time.deltaTime;

            foreach (Material material in myMaterials)
            {
                material.SetFloat("_Sideways_Curve", currentValue);
                material.SetFloat("_Backwards_Curve", backwardsCurrent);
            }

            yield return null;
        }

        isComplete = true;
        currentValue = targetValue;
        backwardsCurrent = backwardsTarget;
    }
}
