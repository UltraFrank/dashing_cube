using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionEndController : MonoBehaviour
{
    [SerializeField] GameObject PlatformSpawner;
    [SerializeField] GameObject restartTab;
    public bool isDead = false;
    public bool sessionEnd = false;
    public int coins;
    public int meters;
    FileManager fileManager;
    // Start is called before the first frame update
    void Awake()
    {
        fileManager = this.gameObject.GetComponent<FileManager>();
        coins = fileManager.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCoins();
    }

    public void HandleCoins()
    {
        if (isDead)
        {
            meters = FindObjectOfType<PauseScript>().finalMeters;
            coins = meters / 10;
            SessionEnding();
            Debug.Log(coins);
        }


    }

    public void SessionStarting()
    {
        PlatformSpawner.SetActive(true);
    }
    public void SessionEnding()
    {
        PlatformSpawner.SetActive(false);
        sessionEnd = true;

    }
    public void GoToMenu()
    {
        isDead = true;
        restartTab.SetActive(false);
    }

    public void HandleCoinsWhenRestart()
    {
        meters = FindObjectOfType<PauseScript>().finalMeters;
        coins = meters / 10;
    }
}
