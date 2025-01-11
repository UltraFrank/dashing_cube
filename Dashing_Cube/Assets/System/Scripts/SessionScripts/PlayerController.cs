using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Gestirà salto, session ending del player e starting position del suddetto
    public float yJump = 8; //Quanto salta
    public bool onTheField = true; //Per evitare che possa fare un doppio salto
    Vector2 ogPosition;

    float timerJump;
    public float maximumHeightSec;

    [SerializeField] private AudioClip jumpClip;

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().Sleep();
        this.ogPosition = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Jump();

        GameOver();
        HandlePlayer();
        Debug.Log("" + onTheField);
        Debug.Log("" + this.gameObject.GetComponent<Rigidbody2D>().sleepMode);

        if (!onTheField)
        {
            timerJump += Time.deltaTime;
            if (this.gameObject.transform.position.y > -4.5f)
                maximumHeightSec = timerJump;
        }


    }
    public void Jump() //Metodo del salto
    {
        if (onTheField)
        {
            if (this.gameObject.GetComponent<Rigidbody2D>().sleepMode == 0)
            {

                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * yJump, ForceMode2D.Impulse);
                if(jumpClip != null)
                    SoundEffectsManager.instance.PlaySoundEffectClip(jumpClip, transform, 1f);
                onTheField = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //Metodo per considerare il limite di salto
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "BasePlatform")
        {
            onTheField = true;
            timerJump = 0;
        }
            
    }

    private void GameOver() //Fine della sessione appena il player si trova sotto -12
    {
        if(this.gameObject.transform.position.y < -12)
        {
            FindObjectOfType<PauseScript>().RestartGame();
            transform.position = ogPosition;
        }


    }

    public void HandlePlayer() //Gestione del player: nell'if potrà muoversi (dopo i sec passati a inizio sessione o dopo pausa); nell'else si fermerà
    {
        PlatformController platformController = FindObjectOfType<PlatformController>();
        if(platformController != null)
        {
            if (platformController.playerMovement)
                this.gameObject.GetComponent<Rigidbody2D>().sleepMode = 0;

            else
                this.gameObject.GetComponent<Rigidbody2D>().Sleep();
        }

    }

    public void OGPosition()
    {
        transform.position = ogPosition;
    }
}
