using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    PlatformController platformController;
    Rigidbody2D playerRB;
    RecordManager recordManager;
    float baseSpeed = 0;

    float numberPause = 0;

    [SerializeField] GameObject pauseBar; //Il tab di controllo della pausa

    [SerializeField] GameObject restartTab;
    // Start is called before the first frame update
    void Start()
    {
        recordManager = gameObject.GetComponentInParent<RecordManager>();
        platformController = GetComponentInChildren<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePause();
    }

    void ActivatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && platformController.isInPause == false && platformController.canPause) //Se si preme ESC una prima volta si va in pausa
        {
            baseSpeed = platformController.speed;
            platformController.speed = 0;
            playerRB = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody2D>();
            playerRB.Sleep();
            pauseBar.SetActive(true);
            numberPause = 0;

            platformController.playerMovement = false;
            platformController.isInPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && platformController.isInPause == true && platformController.canPause) //Se si ripreme ESC si torna in game attivando i sec
                                                                                                                          //di attesa per far ripartire la sessione
        {
            pauseBar.SetActive(false);
            numberPause = 1;
        }
        if (platformController.playerMovement && numberPause == 1) //I secondi sono passati e la sessione riparte
        {
            platformController.speed = baseSpeed;
            playerRB.sleepMode = 0;
            platformController.isInPause = false;
        }
    }

    public void RestartGame()
    {
        baseSpeed = platformController.speed;
        platformController.speed = 0;
        playerRB = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody2D>();
        playerRB.bodyType = RigidbodyType2D.Static;

        restartTab.SetActive(true);
    }

    public void EndRestartTab()
    {
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        platformController.speed = baseSpeed;
    }
}
