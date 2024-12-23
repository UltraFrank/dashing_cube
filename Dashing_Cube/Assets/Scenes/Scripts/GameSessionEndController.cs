using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionEndController : MonoBehaviour
{
    [SerializeField] GameObject PlatformSpawner;
    public bool isDead = false;
    public bool sessionEnd = false;
    public int coins;
    public FileManager fileManager;
    // Start is called before the first frame update
    void Start()
    {
       fileManager = FindObjectOfType<FileManager>();
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
            coins = FindObjectOfType<PlatformController>().meters / 10;
            SessionEnding();
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
        fileManager.inizialize();
    }
}
