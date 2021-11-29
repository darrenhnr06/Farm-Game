using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LandController : MonoBehaviour
{
    public Button[] landBuy;
    public Button[] landSell;

    public TextMeshProUGUI moneyText;
    private int money;
    private int price;

    public GameObject[] landYield;

    public GameObject[] cover; 

    private bool[] landState; 

    private void Awake()
    {
        landBuy[0].onClick.AddListener(UnlockLandOne);
        landBuy[1].onClick.AddListener(UnlockLandTwo);
        landBuy[2].onClick.AddListener(UnlockLandThree);
        landBuy[3].onClick.AddListener(UnlockLandFour);

        landSell[0].onClick.AddListener(SellLandOne);
        landSell[1].onClick.AddListener(SellLandTwo);
        landSell[2].onClick.AddListener(SellLandThree);
        landSell[3].onClick.AddListener(SellLandFour);

        money = 100;
        PlayerPrefs.SetInt("Money", money);


        price = 30;
        moneyText.text = "Money: " + money.ToString();

        landState = new bool[4];
    }

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            landState[i] = false;
        }
    }

    void SellLandOne()
    {
        SellLand(0);
    }

    void SellLandTwo()
    {
        SellLand(1);
    }

    void SellLandThree()
    {
        SellLand(2);
    }

    void SellLandFour()
    {
        SellLand(3);
    }

    void SellLand(int k)
    {
        if(landState[k] == true)
        {
            cover[k].gameObject.SetActive(true);
            money += price;
            PlayerPrefs.SetInt("Money", money);
            landState[k] = false;
            moneyText.text = "Money: " + money.ToString();
        }
    }

    void UnlockLand(int k)
    {
        money -= price;
        if (money >= 0)
        {
            landYield[k].gameObject.SetActive(true);
            moneyText.text = "Money: " + money.ToString();
            landState[k] = true;
            cover[k].gameObject.SetActive(false);
            PlayerPrefs.SetInt("Money", money);
        }
        else
        {
            money += price;
        }
    }


    void UnlockLandOne()
    {
        UnlockLand(0);
    }

    void UnlockLandTwo()
    {
        UnlockLand(1);
    }

    void UnlockLandThree()
    {
        UnlockLand(2);
    }

    void UnlockLandFour()
    {
        UnlockLand(3);
    }
}
