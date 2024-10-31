using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            platforms[i].transform.position = Vector2.MoveTowards(platforms[i].transform.position, new Vector2(-100, platforms[i].transform.position.y), 0.1f);
        }
    }

}
