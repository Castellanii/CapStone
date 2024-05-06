

using TMPro;
using UnityEngine;



public class MenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] Transform EndUI;
    [SerializeField] Transform InstructionUI;
    [SerializeField] Menu menu;

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
        if (PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.StartGame) return;
        if (PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.GameExit) return;
        EnableEndUI();
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
