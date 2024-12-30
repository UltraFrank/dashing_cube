using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Gestirà salto, session ending del player e starting position del suddetto
    [SerializeField] float yJump = 0; //Quanto salta
    bool onTheField = true; //Per evitare che possa fare un doppio salto
    Vector2 ogPosition;

    [SerializeField] private AudioClip jumpClip;

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().Sleep();
        this.ogPosition = transform.position;
    }

    void Update()
    {
        Jump();
        GameOver();
        HandlePlayer();
    }
    void Jump() //Metodo del salto
    {
        if (onTheField)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * yJump, ForceMode2D.Impulse);
                SoundEffectsManager.instance.PlaySoundEffectClip(jumpClip, transform, 1f);
                onTheField = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //Metodo per considerare il limite di salto
    {
        if (collision.gameObject.tag == "Platform")
            onTheField = true;
    }

    private void GameOver() //Fine della sessione appena il player si trova sotto -12
    {
        if(this.gameObject.transform.position.y < -12)
        {
            FindObjectOfType<PauseScript>().RestartGame();
            transform.position = ogPosition;
        }


    }

    private void HandlePlayer() //Gestione del player: nell'if potrà muoversi (dopo i sec passati a inizio sessione o dopo pausa); nell'else si fermerà
    {
        if (FindObjectOfType<PlatformController>().playerMovement)
            this.gameObject.GetComponent<Rigidbody2D>().sleepMode = 0;

        else
            this.gameObject.GetComponent<Rigidbody2D>().Sleep();
    }
}
