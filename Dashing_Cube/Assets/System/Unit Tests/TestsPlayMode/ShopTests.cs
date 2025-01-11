using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTests : MonoBehaviour
{
    private GameObject shopObject;
    private ShopController shopController;
    private MenuController menuController;
    private FileManager fileManager;

    [SetUp]
    public void SetUp()
    {
        // Crea un GameObject con tutti i componenti necessari
        shopObject = new GameObject();
        shopController = shopObject.AddComponent<ShopController>();
        fileManager = shopObject.AddComponent<FileManager>();


        // Inizializza i campi privati con valori di esempio
        shopController.isSkinAcquired = new bool[6] { false, false, false, false, false, false };
        shopController.isAlreadySelected = new bool[6] { false, false, false, false, false, false };
        shopController.coinsRequired = new int[] { 100, 200, 300, 400, 500, 600 };

        shopController.coins = 500;

    }

    // A Test behaves as an ordinary method
    [Test]
    public void ShopTestSimpleSelectionPasses()
    {
        shopController.isSkinAcquired[0] = true;
        shopController.IsSkinSelected0();

        Assert.AreEqual(shopController.isAlreadySelected[0], true);

    }

    [Test]
    public void ShopTestSimpleSelectionFails()
    {
        shopController.isSkinAcquired[0] = false;
        shopController.IsSkinSelected0();

        Assert.AreEqual(shopController.isAlreadySelected[0], false);

    }

    [Test]
    public void ShopTestSimpleAcquisitionPasses()
    {
        shopController.isSkinAcquired[0] = false;
        shopController.coins = 500;
        shopController.IsSkinSelected0();

        Assert.AreEqual(shopController.isSkinAcquired[0], true);

    }

    [Test]
    public void ShopTestSimpleAcquisitionFails()
    {
        shopController.isSkinAcquired[0] = false;
        shopController.coins = 5;
        shopController.IsSkinSelected0();

        Assert.AreEqual(shopController.isSkinAcquired[0], false);

    }

}

