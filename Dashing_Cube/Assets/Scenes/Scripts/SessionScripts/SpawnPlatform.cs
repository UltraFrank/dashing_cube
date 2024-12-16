using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPlatform : MonoBehaviour
{
    PlatformController platformController;
    bool isSpawned = false;
    [SerializeField] GameObject platformSpawner;
    [SerializeField] GameObject platforms;
    private void Start()
    {
        platformController = GetComponentInParent<PlatformController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" && isSpawned)
        {
            isSpawned = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" && !isSpawned)
        {
            float randomNumber = Random.Range(5, 19);
            platformSpawner.transform.localScale = new Vector2(randomNumber, platformController.platforms[0].transform.localScale.y);
            randomNumber = Random.Range(24.6f, 30);
            GameObject newPlatform = Instantiate(platformSpawner, new Vector2(randomNumber, platformController.platforms[0].transform.position.y), Quaternion.identity);
            newPlatform.transform.parent = platforms.transform;
            platformController.platforms.Add(newPlatform);
            isSpawned = true;
        }
    }
   

}
