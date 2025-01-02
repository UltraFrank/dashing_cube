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
    [SerializeField] GameObject settingsTab;
    [SerializeField] GameObject recordsTab;
    [SerializeField] GameObject restartTab;
    [SerializeField] GameObject coinsText;
    [SerializeField] Button[] selectDifficulty;
    [SerializeField] AudioSource[] musics;

    [SerializeField] GameObject[] listofTabs; //Per indice 0 si intende il menu principale, 1 per la scelta livello,
                                              //2 per la sessione livello, 3 per le impostazioni, 4 per record

    private bool isGameActive = false;
    GameSessionEndController gameSessionEndController;
    FileManager fileManager;
    PlatformController platformController;

    [SerializeField] TextMeshProUGUI mediumRecords;

    public int coins = 0;

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

    public void GoToSettings()
    {
        menuTab.SetActive(false);
        settingsTab.SetActive(true);
    }

    public void GoToRecords()
    {
        menuTab.SetActive(false);
        recordsTab.SetActive(true);
        int[] mediumLevelRecords = GetComponent<RecordManager>().LoadRecord();

        mediumRecords.text = ("1°: " + mediumLevelRecords[0] + "\n" + "2°: " + mediumLevelRecords[1] + "\n" + "3°: " + mediumLevelRecords[2]);


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

    public void GoToMenu() 
    {
        foreach(GameObject scene in listofTabs)
            scene.gameObject.SetActive(false);

        menuTab.SetActive(true);
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
        gameSessionEndController.HandleCoinsWhenRestart();
        restartTab.SetActive(false);
        coins += gameSessionEndController.coins;
        fileManager.inizialize();
        GetComponentInChildren<PauseScript>().EndRestartTab();
        GoToNormalLevel();
    }

    
}
