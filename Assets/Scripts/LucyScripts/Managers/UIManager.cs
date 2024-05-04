
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

    [SerializeField] LivesCounter playerLives;

    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] GameObject explosion;
    
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
        explosion.SetActive(false);
        explosionEffect.Stop();
    }


    private void OnEnable()
    {
        hamburgerUI.gameObject.GetComponent<Button>().onClick.AddListener(DisableHamburgerUI);
        playerLives.OnDeath += OnDeath;
    }

    public void UpdateScoreUI(int score)
    {
        //Debug.Log("update score text: " + score);
        scoreTxt.text = $"SCORE: {score}";
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
        playerCondition.GetPlayerRenderer().enabled = false;
        explosion.SetActive(true);
        explosionEffect.Play();
        //TODO add gameover screen
    }



}
