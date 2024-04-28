
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
    }

    public void UpdateScoreUI(int score)
    {
        //Debug.Log("update score text: " + score);
        scoreTxt.text = $"SCORE: {score}";
    }

    public void EnableHamburgerUI()
    {
        hamburgerUI.gameObject.SetActive(true);
    }

    public void DisableHamburgerUI()
    {
        if (hamburgerUI.gameObject.activeSelf == false) return;
        hamburgerUI.gameObject.SetActive(false);
        Debug.Log("activate hamburger mode");
        playerCondition.ActivateHamburgerMode();
        chunkList.HamburgerSpawned(false);

    }



}
