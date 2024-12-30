using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.IK;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject chooseLevel;
    [SerializeField] GameObject menuTab;
    [SerializeField] GameObject gameSession;
    [SerializeField] GameObject restartTab;
    [SerializeField] GameObject coinsText;
    [SerializeField] Button[] selectDifficulty;
    [SerializeField] AudioSource[] musics;

    private bool isGameActive = false;
    GameSessionEndController gameSessionEndController;
    FileManager fileManager;
    PlatformController platformController;

    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameSessionEndController = gameObject.GetComponentInChildren<GameSessionEndController>();
        platformController = gameObject.GetComponentInChildren<PlatformController>();
        fileManager = gameObject.GetComponentInChildren<FileManager>();
        FirstStart();
        musics[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        HandleSession();
    }


    public void GoToSelection()
    {
        menuTab.SetActive(false);
        chooseLevel.SetActive(true);
    }

    public void GoToNormalLevel()
    {
        chooseLevel.SetActive(false);
        gameSession.SetActive(true);
        this.gameObject.GetComponentInChildren<PlatformController>().Init();
        this.gameObject.GetComponentInChildren<PlatformController>().playerMovement = false;
        musics[0].Pause();
        musics[1].Play();
    }

    private void HandleSession()
    {
        isGameActive = gameSessionEndController.sessionEnd;

        if (isGameActive == true)
        {
            coins += gameSessionEndController.coins;
            coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins;
            isGameActive = false;
            this.gameObject.GetComponentInChildren<PlatformController>().timer = 0;
            gameSessionEndController.sessionEnd = false;
            gameSessionEndController.isDead = false;
            gameSession.SetActive(false);
            menuTab.SetActive(true);
            fileManager.inizialize();
        }
    }
    private void FirstStart()
    {
        coins += gameSessionEndController.coins;
        coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins;
    }

    public void RestartGame()
    {
        restartTab.SetActive(false);
        GoToNormalLevel();
    }

    
}
