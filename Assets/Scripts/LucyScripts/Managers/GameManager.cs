

using UnityEngine;

public enum GameStatus
{
    GameEnter,
    StartGame,
    InGame,
    GameEnd,
    GameExit

}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
   
    public GameStatus gameStatus { get; private set; }



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


    private void Start()
    {
        if (PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.GameExit)
        {
            PlayerPrefs.SetInt("gameStatus", (int)GameStatus.GameEnter);
            MenuInteractor.Instance.SetEnabled(true);
            return;
        }
        if (PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.StartGame) return;
        if (PlayerPrefs.GetInt("gameStatus") == (int)GameStatus.GameExit) return;
       
        //Active End Menu
        MenuUI.Instance.EnableEndUI();
    }

    public void UpdateFinalScore(int _finalScore)
    {
        PlayerPrefs.SetInt("finalScore", _finalScore);
    }

    public void PlayerDead()
    {
        EndGame();
    }

    public void EndGame()
    {
        UpdateFinalScore(UIManager.instance.currScore);

        PlayerPrefs.SetInt("gameStatus", (int)GameStatus.GameEnd);
        SceneChanger.instance.ChangeScene("MenuScene");
        

        //MenuUI.Instance.EnableEndUI();
    }


    public void StartGame()
    {
        PlayerPrefs.SetInt("gameStatus", (int)GameStatus.StartGame);
        SceneChanger.instance.ChangeScene("FinalScene");
        

    }
    void OnApplicationQuit()
    {
        // Code to execute when the application is quitting
        Debug.Log("Application quitting...");
        PlayerPrefs.SetInt("gameStatus", (int)GameStatus.GameExit);
    }




}
