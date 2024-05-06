

using UnityEngine;

public enum GameStatus
{
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


    

}
