using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    PlatformController platformController;
    Rigidbody2D playerRB;
    float baseSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
       platformController = GetComponentInChildren<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePause();
        
    }

    void ActivatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && platformController.isInPause == false)
        {
            baseSpeed = platformController.speed;
            platformController.speed = 0;
            playerRB = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody2D>();
            playerRB.Sleep();
            Debug.Log("Menu attivo di pausa");
            platformController.isInPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && platformController.isInPause == true)
        {
            platformController.speed = baseSpeed;
            playerRB.sleepMode = 0;
            platformController.isInPause = false;
            Debug.Log("Menu disattivato");

        }
    }
}
