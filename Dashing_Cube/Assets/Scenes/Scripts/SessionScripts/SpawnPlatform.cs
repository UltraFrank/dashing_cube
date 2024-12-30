using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPlatform : MonoBehaviour
{
    PlatformController platformController; //Richiamo allo script platformcontroller
    bool isSpawned = false;  //Gestione dello spawn
    [SerializeField] GameObject basePlatform; //Oggetto che servir� a far spawnare piattaforme
    [SerializeField] GameObject platforms; //Lista di piattaforme

    [SerializeField] GameObject setOfBasePlatforms;

    GameObject platformSpawner;
    private void Start()
    {
        platformController = GetComponentInParent<PlatformController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Platform" || collision.gameObject.tag == "BasePlatform") && isSpawned)
        {
            isSpawned = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Appena una piattaforma lascer� lo spazio dello spawn, ne far� spawnare un'altra dall'altro lato
    {
        if ((collision.gameObject.tag == "Platform" || collision.gameObject.tag == "BasePlatform")  && !isSpawned)
        {
            platformSpawner = basePlatform;
            float randomNumber = Random.Range(5, 9); //Float che decide il cambio di scale nell'asse x della nuova piattaforma spawnata
            platformSpawner.transform.localScale = new Vector2(randomNumber, platformController.platforms[0].transform.localScale.y);
            randomNumber = Random.Range(40, 42); //Float che decide in che punto x far spawnare la piattaforma
            GameObject newPlatform = Instantiate(platformSpawner, new Vector2(randomNumber, platformController.platforms[0].transform.position.y), Quaternion.identity);
            newPlatform.transform.parent = platforms.transform;
            platformController.platforms.Add(newPlatform); //Aggiunge la piattaforma alla lista delle piattaforme, con valori randomici sulla lunghezza
                                                           //e distanza da un'altra piattaforma
            isSpawned = true;
        }
    }


}
