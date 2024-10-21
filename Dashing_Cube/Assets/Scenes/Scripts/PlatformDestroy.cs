using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    PlatformController platformController;
    bool isDestroyed = false;
    private void Start()
    {
        platformController = GetComponentInParent<PlatformController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ciao2");
        if (collision.gameObject.tag == "Platform" && !isDestroyed)
        {
            Destroy(platformController.platforms[0]);
            platformController.platforms.RemoveAt(0);
            isDestroyed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isDestroyed)
            isDestroyed = false;
    }
}
