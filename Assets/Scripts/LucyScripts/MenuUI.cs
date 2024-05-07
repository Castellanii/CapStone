

using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class MenuUI : MonoBehaviour
{
    [SerializeField] Text ScoreTxt;
    [SerializeField] Transform EndUI;
    [SerializeField] Transform InstructionUI;
    [SerializeField] MenuInteractor menu;

    [SerializeField] public GameObject UIPanel;
    [SerializeField] public Text UIText;

    public static MenuUI Instance;

    void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    private void Awake()
    {
        Singleton();
        
    }

    public void EnableEndUI()
    {

        EndUI.gameObject.SetActive(true);
        menu.SetEnabled(false);
        UpdateScore(PlayerPrefs.GetInt("finalScore"));   
        
    }
    public void EnableInstructionUI()
    {
        Debug.Log("set instrcution active");
        menu.SetEnabled(false);
        InstructionUI.gameObject.SetActive(true);   
    }


    public void UpdateScore(int _score)
    {
        ScoreTxt.text = "Your highest Score: " + _score.ToString();
    }
}
