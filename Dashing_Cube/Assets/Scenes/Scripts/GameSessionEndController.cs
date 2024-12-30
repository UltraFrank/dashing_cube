using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionEndController : MonoBehaviour
{
    [SerializeField] GameObject PlatformSpawner;
    public bool isDead = false;
    public bool sessionEnd = false;
    public int coins;
    public int meters;
    FileManager fileManager;
    RecordManager recordManager;
    // Start is called before the first frame update
    void Awake()
    {
        fileManager = this.gameObject.GetComponent<FileManager>();
        recordManager = this.gameObject.GetComponent<RecordManager>();
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
            coins = FindObjectOfType<PlatformController>().meters / 10;
            meters = coins * 10;
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

    }
}
