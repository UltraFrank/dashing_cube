using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float speed = 0.05f;
    [SerializeField] TextMeshProUGUI metersText;
    public float timer = 0;
    public int meters = 0;
    public bool isInPause = false;
    public bool playerMovement = false;

    [SerializeField] GameObject basePlatforms;
    bool isFirstGame = true;

    public bool canPause = false;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        canPause = false;
        if (!isFirstGame)
        {
            DestroyAllRemainingPlatforms();
            platforms[0].transform.position = new Vector2(26.5f, platforms[0].transform.position.y);
            basePlatforms.transform.position = new Vector2(-0.600000024f, basePlatforms.transform.position.y);
        }

        speed = 0;
        StartCoroutine(GameStarting());
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        SpeedOMeter();
        BreakFromPause();

    }

    void MovePlatform() //Movimento Piattaforme
    {
        basePlatforms.transform.position = Vector2.MoveTowards(basePlatforms.transform.position, new Vector2(-100, basePlatforms.transform.position.y), speed);
        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].transform.position = Vector2.MoveTowards(platforms[i].transform.position, new Vector2(-100, platforms[i].transform.position.y), speed);
        }

    }

    void SpeedOMeter()
    {
        if (!isInPause)
        {
            timer += Time.deltaTime;
            meters = (int)(timer * speed * 150); //Calcolo dei metri con il processo inverso di metri/secondo della velocità * 150 che è un numero fittizio per renderlo realistico
            metersText.text = "Meters: " + meters;
        }

    }

    void BreakFromPause() //Fine della pausa e inizio dei secondi di attesa
    {
        if (isInPause && Input.GetKeyDown(KeyCode.Escape))
        {
            speed = 0;
            StartCoroutine(GameStarting());
        }
    }

    void DestroyAllRemainingPlatforms()
    {
        for (int i = 1; i < platforms.Count; i++) // Start from 1 to skip the first element
        {
            if (platforms[i] != null)
            {
                Destroy(platforms[i]); // Destroy the GameObject
                
            }
        }
        platforms.RemoveRange(1, platforms.Count - 1);
    }

    IEnumerator GameStarting() //Il calcolo dei secondi di attesa effettivi
    {

        yield return new WaitForSeconds(5);
        speed = 0.05f;
        if (isInPause)
            timer += 0;
        else
        timer = 0;
        playerMovement = true;
        isFirstGame = false;
        canPause = true;
    }
}
