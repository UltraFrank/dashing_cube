using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    [SerializeField] float speed = 0.05f;
    [SerializeField] TextMeshProUGUI metersText;
    public float timer = 0;
    public int meters = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        SpeedOMeter();
    }

    void MovePlatform()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            platforms[i].transform.position = Vector2.MoveTowards(platforms[i].transform.position, new Vector2(-100, platforms[i].transform.position.y), speed);
        }
    }

    void SpeedOMeter()
    {
        timer += Time.deltaTime;
        meters = (int)(timer * speed * 150); //Calcolo dei metri con il processo inverso di metri/secondo della velocità * 150 che è un numero fittizio per renderlo realistico
        metersText.text = "Meters: " + meters;
    }

}
