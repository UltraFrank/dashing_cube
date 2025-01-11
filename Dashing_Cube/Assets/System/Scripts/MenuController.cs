using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    //***** PER TAB SI INTENDONO DIVERSE SEZIONI DI GIOCO, DIVISE PERCHE' OGNUNA DI ESSE AGIRA' IN MANIERA INDIPENDENTE
    //(con uniche relazioni di padre/figlio in alcuni casi) *****


    [SerializeField] GameObject menuTab;      //Tab del menu principale, da dove si dirama tutto
    [SerializeField] GameObject chooseLevel;  //Tab della scelta del livello di selezione della sessione di gioco
    [SerializeField] GameObject gameSession;  //Tab della sessione di gioco, da dove partirà il livello scelto
    [SerializeField] GameObject settingsTab;  //Tab delle impostazioni, dove potrà essere gestito il volume di gioco
    [SerializeField] GameObject recordsTab;   //Tab dei record, dove potranno essere visualizzati i record
    [SerializeField] GameObject restartTab;   //Tab del restart (dipendente da gameSession), che mostrerà i pulsanti di ritorno al menù o riavvio
    [SerializeField] GameObject shopTab;

    [SerializeField] GameObject[] listofTabs; //Per indice 0 si intende il menu principale, 1 per la scelta livello,
                                              //2 per la sessione livello, 3 per le impostazioni, 4 per record, 5 per lo shop

    [SerializeField] GameObject coinsText;    //Testo delle monete presente da visualizzare nel menù

    [SerializeField] Button[] selectDifficulty; //Pulsanti di selezione di difficoltà della sessione di gioco

    [SerializeField] AudioSource[] musics;     //Elenco di TUTTE le musiche presenti in gioco

    [SerializeField] TextMeshProUGUI easyRecords;     //Classifica dei top 3 record del livello facile presente nel RecordTab
    [SerializeField] TextMeshProUGUI mediumRecords;   //Classifica dei top 3 record del livello medio presente nel RecordTab
    [SerializeField] TextMeshProUGUI hardRecords;     //Classifica dei top 3 record del livello difficile presente nel RecordTab

    private bool isGameActive = false;   //Flag che controlla se una sessione di gioco è in corso oppure no
    public bool isEasy = false;
    public bool isNormal = false;
    public bool isHard = false;


    GameSessionEndController gameSessionEndController; //Richiamo dello script GameSessionEndController, per il controllo della fine di una sessione di gioco
    FileManager fileManager;                           //Richiamo dello script FileManager, utile per la gestione delle monete



    public int coins = 0;                               //Valore delle monete

    void Awake()
    {
        gameSessionEndController = gameObject.GetComponentInChildren<GameSessionEndController>();
        fileManager = gameObject.GetComponentInChildren<FileManager>();

        //Visualizza le monete caricate dal file di memorizzazione di esse
        FirstStart(); 

        //Parte la musica del menù di gioco
        musics[0].Play();

        
        fileManager.inizialize();
    }


    void Update()
    {
        HandleSession();
    }
    private void FirstStart()  //Controllo delle monete caricate dal file di memorizzazione
    {
        if (gameSessionEndController != null )
        {
            coins += gameSessionEndController.coins;
            coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins;
        }

    }

    public void GoToSelection()  //Attivazione tab di selezione del livello
    {
        menuTab.SetActive(false);
        chooseLevel.SetActive(true);
    }
    public void GoToEasyLevel()  //Attivazione della sessione di gioco
    {
        chooseLevel.SetActive(false);
        gameSession.SetActive(true);

        isEasy = true;
        isNormal = false;
        isHard = false;

        //Metodo che inizializza le componenti del livello di gioco utili allo start di esso
        this.gameObject.GetComponentInChildren<PlatformController>().Init();

        //Movimento del player posto a false per poter avere un inizio di gioco rinviato di qualche secondo dall'inizio del caricamento della sessione
        this.gameObject.GetComponentInChildren<PlatformController>().playerMovement = false;

        musics[0].Pause(); //Musica del menù stoppata
        musics[1].Play();  //Musica del livello
    }
    public void GoToNormalLevel()  //Attivazione della sessione di gioco
    {
        chooseLevel.SetActive(false);
        gameSession.SetActive(true);

        isEasy = false;
        isNormal = true;
        isHard = false;

        //Metodo che inizializza le componenti del livello di gioco utili allo start di esso
        this.gameObject.GetComponentInChildren<PlatformController>().Init();

        //Movimento del player posto a false per poter avere un inizio di gioco rinviato di qualche secondo dall'inizio del caricamento della sessione
        this.gameObject.GetComponentInChildren<PlatformController>().playerMovement = false;

        musics[0].Pause(); //Musica del menù stoppata
        musics[1].Play();  //Musica del livello
    }
    public void GoToHardLevel()  //Attivazione della sessione di gioco
    {
        chooseLevel.SetActive(false);
        gameSession.SetActive(true);

        isEasy = false;
        isNormal = false;
        isHard = true;

        //Metodo che inizializza le componenti del livello di gioco utili allo start di esso
        this.gameObject.GetComponentInChildren<PlatformController>().Init();

        //Movimento del player posto a false per poter avere un inizio di gioco rinviato di qualche secondo dall'inizio del caricamento della sessione
        this.gameObject.GetComponentInChildren<PlatformController>().playerMovement = false;

        musics[0].Stop(); //Musica del menù stoppata
        musics[1].Play();  //Musica del livello
    }

    public void GoToSettings()  //Attivazione tab delle impostazioni
    {
        menuTab.SetActive(false);
        settingsTab.SetActive(true);
    }

    public void GoToRecords()   //Attivazione tab di visualizzazione dei record
    {
        menuTab.SetActive(false);
        recordsTab.SetActive(true);


        //Gestisce i record del livello medio richiamando il RecordManager
        int[] easyLevelRecords = GetComponent<RecordManager>().LoadEasyRecord();
        int[] mediumLevelRecords = GetComponent<RecordManager>().LoadMediumRecord();
        int[] hardLevelRecords = GetComponent<RecordManager>().LoadHardRecord();

        //Visualizzazione testuale dei record
        easyRecords.text = ("1°: " + easyLevelRecords[0] + "\n" + "2°: " + easyLevelRecords[1] + "\n" + "3°: " + easyLevelRecords[2]);
        mediumRecords.text = ("1°: " + mediumLevelRecords[0] + "\n" + "2°: " + mediumLevelRecords[1] + "\n" + "3°: " + mediumLevelRecords[2]);
        hardRecords.text = ("1°: " + hardLevelRecords[0] + "\n" + "2°: " + hardLevelRecords[1] + "\n" + "3°: " + hardLevelRecords[2]);


    }

    public void GoToShop()
    {
        menuTab.SetActive(false);
        shopTab.SetActive(true);
    }

    public void GoToMenu()  //Attivazione tab del menu disattivando tutti gli altri tab
    {
        //Richiamo di ogni tab, presenti in un array, per la disattivazione di essi (vien fatto per usare un solo metodo per i pulsanti di ritorno al menù)
        foreach(GameObject scene in listofTabs)
            scene.gameObject.SetActive(false);

        coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins; //Monete aggiornate
        musics[1].Stop(); //Musica del livello stoppata
        musics[0].Play();  //Musica del menù

        menuTab.SetActive(true);
    }

    private void HandleSession()  //Gestione dell'aggiornamento di varie componenti a fine di una sessione di gioco
    {
        //Boolean aggiornato dallo script GameSessionEndController per controllare se una sessione è finita
        isGameActive = gameSessionEndController.sessionEnd;  

        if (isGameActive == true) //Se sessione conclusa
        {
            musics[1].Stop(); //Musica del livello stoppata
            musics[0].Play();  //Musica del menù

            coins += gameSessionEndController.coins;  //Aggiornamento monete
            coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins; //Aggiornamento testo delle monete sul menù
            isGameActive = false;
            this.gameObject.GetComponentInChildren<PlatformController>().timer = 0; //Timer riposto a 0 per prossima sessione

            //Disattivazione di fine sessione e di morte del giocatore
            gameSessionEndController.sessionEnd = false;
            gameSessionEndController.isDead = false;

            gameSession.SetActive(false);
            menuTab.SetActive(true);

            //Aggiornamento delle monete nel file di memorizzazione
            fileManager.inizialize();
        }
    }
    public void RestartGame()  //Metodo richiamato dal pulsante di riavvio del gioco
    {
        //Richiamo di un metodo in GameSessionEndController per aggiornare le monete ottenute
        gameSessionEndController.HandleCoinsWhenRestart();
        restartTab.SetActive(false);

        //Aggiornamento monete per il menù
        coins += gameSessionEndController.coins;
        //Aggiornamento delle monete nel file di memorizzazione
        fileManager.inizialize();

        GetComponentInChildren<PauseScript>().EndRestartTab();

        //Riavvio di una nuova sessione di gioco
        if (isEasy)
            GoToEasyLevel();
        else if (isNormal)  
            GoToNormalLevel();
        else if (isHard)
            GoToHardLevel();
    }  
}
