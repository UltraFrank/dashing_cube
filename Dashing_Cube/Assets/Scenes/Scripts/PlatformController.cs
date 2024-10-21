using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    [SerializeField] GameObject spawnPlatform;
    bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        EliminatePlatform();
        InstatiatePlatform();
    }

    void MovePlatform()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            platforms[i].transform.position = Vector2.MoveTowards(platforms[i].transform.position, new Vector2(-100, platforms[i].transform.position.y), 0.1f);
        }
    }
    void EliminatePlatform()
    {
        if (platforms[0].gameObject.transform.position.x < -30)
        {
            Destroy(platforms[0]);
            platforms.RemoveAt(0);
        }
    }

    void InstatiatePlatform()
    {
        if (platforms[0].gameObject.transform.position.x < -26 && !isSpawned)
        {
            float randomNumber = Random.Range(4, 12);
            spawnPlatform.transform.localScale = new Vector2(randomNumber, platforms[0].transform.localScale.y);
            randomNumber = Random.Range(24.6f, 27);
            platforms.Add(Instantiate(spawnPlatform, new Vector2(randomNumber, platforms[0].transform.position.y), Quaternion.identity));
            isSpawned = true;
        }

        else if (platforms[0].gameObject.transform.position.x > -26)
            isSpawned = false;
    }


    //FARE ELIMINATEPLATFORM E INSTATIATE NEL COLLISIONENTER
}
