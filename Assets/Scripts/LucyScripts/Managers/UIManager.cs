
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: after hamburger is made, connect event to EnableScoreUI
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;

    [SerializeField] Transform hamburgurUI;


    
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


    private void OnEnable()
    {
        hamburgurUI.gameObject.GetComponent<Button>().onClick.AddListener(DisableHamburgerUI);
    }

    public void UpdateScoreUI(int score)
    {
        //Debug.Log("update score text: " + score);
        scoreTxt.text = $"SCORE: {score}";
    }

    public void EnableHamburgerUI()
    {
        hamburgurUI.gameObject.SetActive(true);
    }

    public void DisableHamburgerUI()
    {
        hamburgurUI.gameObject.SetActive(false);
    }



}
