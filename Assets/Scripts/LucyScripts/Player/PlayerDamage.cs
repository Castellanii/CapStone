using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Color damageColor;
    [SerializeField] private float damageDuration = 1.0f;
    [SerializeField] private float colorFrequency = 3f;
    [SerializeField] private LivesCounter livesCounter;

    private ShapeShiftInteractor shapeShiftInteractor;
    private PlayerCondition playerCondition;
    private float colorDuration;

    private Color[] startColors;
    private Material[] currMaterials;
    public static PlayerDamage instance;

    private bool isDamaged;
    private void OnEnable()
    {
        playerCondition.UpdateCurrMaterial += UpdateCurrMaterial;
    }

    private void Singleton()
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
        isDamaged = false;

    }

    private void OnDestroy()
    {
        livesCounter.OnDamage -= GetDamage;
    }

    public void GetDamage()
    {
        //Debug.Log("get Damage");
        isDamaged = true;
        currMaterials = playerCondition.GetPlayerRenderer().materials;
        startColors = new Color[currMaterials.Length];
        for (int i = 0; i < currMaterials.Length; i++)
        {
            //Debug.Log($"{currMaterials[i].name} with color {currMaterials[i].color}");
            startColors[i] = currMaterials[i].color;
        }
        StartCoroutine(LerpColor());
        
    }

    IEnumerator LerpColor()
    {
        for (int i = 0; i < colorFrequency; i++)
        {
            
            for (int j = 0; j < currMaterials.Length; j++)
            {
                currMaterials[j].color = Color.Lerp(startColors[j], damageColor, colorDuration);
            }
            
            yield return new WaitForSeconds(colorDuration / 2);

            for (int j = 0; j < currMaterials.Length; j++)
            {
                currMaterials[j].color = Color.Lerp(damageColor, startColors[j], colorDuration);
                currMaterials[j].color = startColors[j];
            }

            yield return new WaitForSeconds(colorDuration / 2);

            
        }
        isDamaged = false;


    }
    public void UpdateCurrMaterial()
    {
        if (!isDamaged) return;
        //Debug.Log($"the shapechange occur in damage effect in {currMaterials[0].name}");
        
        //the old material back to origin
        for (int j = 0; j < currMaterials.Length; j++)
        {
            currMaterials[j].color = startColors[j];
        }
        //the new material continue the damage effect
        currMaterials = playerCondition.GetPlayerRenderer().materials;
       
    }
}
