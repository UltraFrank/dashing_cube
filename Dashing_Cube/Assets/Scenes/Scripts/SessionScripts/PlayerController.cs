using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float yJump = 0;
    bool onTheField = true;
    Vector2 ogPosition;

    private void Start()
    {
        this.ogPosition = transform.position;
    }

    void Update()
    {
        Jump();
        GameOver();
    }
    void Jump()
    {
        if (onTheField)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * yJump, ForceMode2D.Impulse);
                onTheField = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            onTheField = true;
    }

    private void GameOver()
    {
        if(this.gameObject.transform.position.y < -12)
        {
            FindObjectOfType<GameSessionEndController>().isDead = true;
            transform.position = ogPosition;
        }


    }
}
