using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionEndController : MonoBehaviour
{
    [SerializeField] GameObject PlatformSpawner; //Richiamo dell'oggetto CollisionSpawn, necessario per essere disattivato a fine sessione e attivato ad inizio sessione
    [SerializeField] GameObject restartTab;      //Richiamo dell'oggetto RestartBar, necessario per essere disattivato

    public bool isDead = false;                  //Bool di morte del giocatore (1° flag di fine sessione)
    public bool sessionEnd = false;              //Bool di conclusione della sessione di gioco (2° flag di fine sessione)
    public int coins;                            //Valore che conterrà le monete acquisite in una sessione
    public int meters;                           //Metri percorsi nella corrente sessione di gioco

    FileManager fileManager;                     //Richiamo dello script FileManager

    void Awake()
    {
        fileManager = this.gameObject.GetComponent<FileManager>(); //Inizializzazione della variabile FileManager
        coins = fileManager.LoadCoinsData(); //E' il momento in cui l'INTERO GIOCO richiama le monete nel file di memoria delle monete
    }


    void Update()
    {
        HandleCoins();
    }

    public void HandleCoins()  //Gestisce la trasformazione dei metri percorsi nella sessione di gioco corrente in monete spendibili nel negozio
    {
        if (isDead)
        {
            meters = FindObjectOfType<PauseScript>().finalMeters;   //Richiamo dei metri finali percorsi, presente nello script PauseScript
            coins = meters / 10;                                    // Monete calcolate prendendo i metri percorsi diviso 10 (valore indicativo)
            SessionEnding();
        }


    }

    public void SessionStarting()          //Metodo che viene richiamato dal pulsante di creazione della nuova sessione di gioco, che ha come unico scopo
                                           //la riattivazione dell'oggetto di Spawn delle piattaforme
    {
        PlatformSpawner.SetActive(true);         
    }
    public void SessionEnding()
    {
        PlatformSpawner.SetActive(false); //Per evitare possibili conflitti con la disattivazione di determinati oggetti, disattiviamo lo spawn di piattaforme
                                          //nel momento in cui la sessione di gioco stessa si concluderà

        sessionEnd = true;                //Bool di fine sessione richiamato nel MenuController

    }
    public void GoToMenu()                //Metodo richiamato dal pulsante di passaggio da fine sessione a menù, che disattiverà il Tab del Restart di fine game
                                          //e porterà il 1° flag di sessione a true, cominciando la catena di aggiornamenti di valori e ritorno al menu stesso
    {
        isDead = true;
        restartTab.SetActive(false);
    }

    public void HandleCoinsWhenRestart()                      //Metodo per aggiornare le monete in caso di riavvio diretto di una partita, viene richiamato da un metodo
                                                              //presente nello script MenuController
    {
        meters = FindObjectOfType<PauseScript>().finalMeters; //Richiamo dei metri finali percorsi, presente nello script PauseScript
        coins = meters / 10;                                  // Monete calcolate prendendo i metri percorsi diviso 10 (valore indicativo)
    }
}
