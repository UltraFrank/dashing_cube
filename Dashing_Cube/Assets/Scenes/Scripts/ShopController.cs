using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using System.Drawing;

public class ShopController : MonoBehaviour
{
    [HideInInspector]  public bool[] isSkinAcquired;
    [SerializeField] UnityEngine.Color[] colorsSkins;
    [SerializeField] int[] coinsRequired;
    [SerializeField] Button[] buttonsShop;
    [SerializeField] GameObject player;
    [SerializeField] GameObject coinsText;
    FileManager fileManager;
    GameSessionEndController gameSessionEndController;
    bool[] isAlreadySelected;
    int coins;
    
    // Start is called before the first frame update
    void Awake()
    {

        isAlreadySelected = new bool[] { true, false, false, false, false, false };
        fileManager = GetComponentInChildren<FileManager>();
        gameSessionEndController = GetComponentInChildren<GameSessionEndController>();
        isSkinAcquired = fileManager.LoadShopData();

        coins += gameSessionEndController.coins;
        coinsText.gameObject.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeRightSkin()
    {
        for(int i = 0; i < isSkinAcquired.Length; i++)
        {
            if (isSkinAcquired[i])
            {
                if (isAlreadySelected[i])
                    player.gameObject.GetComponent<SpriteRenderer>().color = colorsSkins[i];
            }
        }
    }


    public void IsSkinSelected0()
    {
        if((GetComponent<MenuController>().coins >= coinsRequired[0]) && !isSkinAcquired[0])
        {
            GetComponent<MenuController>().coins -= coinsRequired[0];
            isSkinAcquired[0] = true;
            buttonsShop[0].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[0] && !isAlreadySelected[0])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[0] = true;
            buttonsShop[0].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }
        fileManager.inizialize();

        if (isAlreadySelected[0])
        {
            //Bottone in grigio
        }
    }

    public void IsSkinSelected1()
    {
        if ((GetComponent<MenuController>().coins >= coinsRequired[1]) && !isSkinAcquired[1])
        {
            GetComponent<MenuController>().coins -= coinsRequired[1];
            isSkinAcquired[1] = true;
            buttonsShop[1].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[1] && !isAlreadySelected[1])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[1] = true;
            buttonsShop[1].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }

        if (isAlreadySelected[1])
        {
            //Bottone in grigio
        }
        fileManager.inizialize();
    }

    public void IsSkinSelected2()
    {
        if ((GetComponent<MenuController>().coins >= coinsRequired[2]) && !isSkinAcquired[2])
        {
            GetComponent<MenuController>().coins -= coinsRequired[2];
            isSkinAcquired[2] = true;
            buttonsShop[2].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[2] && !isAlreadySelected[2])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[2] = true;
            buttonsShop[2].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }

        if (isAlreadySelected[2])
        {
            //Bottone in grigio
        }

        fileManager.inizialize();
    }

    public void IsSkinSelected3()
    {
        if ((GetComponent<MenuController>().coins >= coinsRequired[3]) && !isSkinAcquired[3])
        {
            GetComponent<MenuController>().coins -= coinsRequired[3];
            isSkinAcquired[3] = true;
            buttonsShop[3].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[3] && !isAlreadySelected[3])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[3] = true;
            buttonsShop[3].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }

        if (isAlreadySelected[3])
        {
            //Bottone in grigio
        }

        fileManager.inizialize();
    }

    public void IsSkinSelected4()
    {
        if ((GetComponent<MenuController>().coins >= coinsRequired[4]) && !isSkinAcquired[4])
        {
            GetComponent<MenuController>().coins -= coinsRequired[4];
            isSkinAcquired[4] = true;
            buttonsShop[4].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[4] && !isAlreadySelected[4])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[4] = true;
            buttonsShop[4].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }

        if (isAlreadySelected[4])
        {
            //Bottone in grigio
        }

        fileManager.inizialize();
    }

    public void IsSkinSelected5()
    {
        if ((GetComponent<MenuController>().coins >= coinsRequired[5]) && !isSkinAcquired[5])
        {
            GetComponent<MenuController>().coins -= coinsRequired[5];
            isSkinAcquired[5] = true;
            buttonsShop[5].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Seleziona";
            //Sound effect acquisto

        }
        else if (isSkinAcquired[5] && !isAlreadySelected[5])
        {
            //Modifica della skin del player
            for (int i = 0; i < isAlreadySelected.Length; i++)
            {
                isAlreadySelected[i] = false;
            }
            isAlreadySelected[5] = true;
            buttonsShop[5].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Selezionato";
        }

        if (isAlreadySelected[5])
        {
            //Bottone in grigio
        }

        fileManager.inizialize();
    }
}
