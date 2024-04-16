
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;


    
    public static UIManager instance;

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
    }


    public void UpdateScoreUI(int score)
    {
        //Debug.Log("update score text: " + score);
        scoreTxt.text = $"SCORE: {score}";
    }
}
