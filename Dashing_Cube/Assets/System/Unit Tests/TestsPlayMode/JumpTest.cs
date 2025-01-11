using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JumpTest
{

    [UnityTest]
    public IEnumerator JumpTestPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var player = new GameObject();
        var playerController = player.AddComponent<PlayerController>();
        var rb = player.AddComponent<Rigidbody2D>();

        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        playerController.onTheField = true;
        playerController.yJump = 8f;


        playerController.Jump();



        yield return new WaitForSeconds(0);

        Assert.AreEqual(playerController.onTheField, false);
    }

    [UnityTest]
    public IEnumerator JumpTestFailes()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var player = new GameObject();
        var playerController = player.AddComponent<PlayerController>();
        var rb = player.AddComponent<Rigidbody2D>();

        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        playerController.onTheField = false;
        playerController.yJump = 8f;


        playerController.Jump();



        yield return new WaitForSeconds(playerController.maximumHeightSec);

        Assert.AreEqual(playerController.onTheField, false);  //La logica è che il salto non viene eseguito proprio e per questo motivo non rientra nel metodo
    }
}
