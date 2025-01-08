using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    PlatformController platformController; //Richiamo allo Script PlatformController
    bool isDestroyed = false;   //Controlla se una particolare piattaforma è stata distrutta
    private void Start()
    {
        platformController = GetComponentInParent<PlatformController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)   //Appena c'è collisione con l'oggetto invisibile che distrugge le platforms, distrugge la platform
    {
        if (collision.gameObject.tag == "Platform" && !isDestroyed)
        {
            Destroy(platformController.platforms[0]);
            platformController.platforms.RemoveAt(0);
            isDestroyed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //Check booleano rimesso a false
    {
        if(isDestroyed)
            isDestroyed = false;
    }
}
