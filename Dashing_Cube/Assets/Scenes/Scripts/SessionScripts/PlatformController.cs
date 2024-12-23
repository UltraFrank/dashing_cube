using System;
using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
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
        if(isInPause && Input.GetKeyDown(KeyCode.Escape))
        {
            speed = 0;
            StartCoroutine(GameStarting());
        }
    }

    IEnumerator GameStarting() //Il calcolo dei secondi di attesa effettivi
    {
        yield return new WaitForSeconds(5);
        speed = 0.05f;
        timer = 0;
        playerMovement = true;
    }
}
