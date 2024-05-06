
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: after hamburger is made, connect event to EnableScoreUI
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;

    [SerializeField] Transform hamburgerUI;

    [SerializeField] PlayerCondition playerCondition;

    [SerializeField] ChunkList chunkList;

    public static UIManager instance;

    private bool pause;

    public int currScore { get; private set; }
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
        playerCondition.EnableHamburgerUI += EnableHamburgerUI;
    }


    private void OnEnable()
    {
        hamburgerUI.gameObject.GetComponent<Button>().onClick.AddListener(DisableHamburgerUI);
        LivesCounter.Instance.OnDeath += OnDeath;
    }

    public void UpdateScoreUI(int score)
    {
        //Debug.Log("update score text: " + score);
        if (pause) return;
        scoreTxt.text = $"SCORE: {score}";
        currScore = score;
    }

    private void EnableHamburgerUI()
    {
        hamburgerUI.transform.GetComponent<Button>().interactable = true;
        hamburgerUI.gameObject.SetActive(true);
    }

    public void DisableHamburgerUI()
    {
        hamburgerUI.transform.GetComponent<Button>().interactable = false;
        hamburgerUI.gameObject.SetActive(false);
        //Debug.Log("activate hamburger mode");
        playerCondition.ActivateHamburgerMode();
        chunkList.HamburgerSpawned(false);

    }

    void OnDeath()
    {
        Debug.Log($"Player is Dead");
        pause = true;
        //playerCondition.gameObject.SetActive(false);
        playerCondition.GetPlayerRenderer().enabled = false;
        //TODO add gameover screen
    }



}
