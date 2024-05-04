using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Color damageColor;
    [SerializeField] private float damageDuration = 1.0f;
    [SerializeField] private float colorFrequency = 3f;
    [SerializeField] private LivesCounter livesCounter;

    private PlayerCondition playerCondition;
    private float colorDuration;

    private Color startColor;
    private Material currMaterial;
    public static PlayerDamage instance;

    private 

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
        playerCondition = GetComponent<PlayerCondition>();

        livesCounter.OnDamage += GetDamage;
    }

    private void Start()
    {
        colorDuration = damageDuration / colorFrequency;


    }

    private void OnDestroy()
    {
        livesCounter.OnDamage -= GetDamage;
    }

    public void GetDamage()
    {
        Debug.Log("get Damage");
        currMaterial = playerCondition.GetPlayerRenderer().material;
        startColor = currMaterial.color;    
        StartCoroutine(LerpColor());
        
    }

    IEnumerator LerpColor()
    {

        for (int i = 0; i < colorFrequency; i++)
        {
            currMaterial.color = Color.Lerp(startColor, damageColor, colorDuration);
            yield return new WaitForSeconds(colorDuration / 2);
            currMaterial.color = Color.Lerp(damageColor, startColor, colorDuration);
            yield return new WaitForSeconds(colorDuration / 2);
        }
        currMaterial.color = startColor;
    }
}
