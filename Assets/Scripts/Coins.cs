using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static Coins instance;
    private void Awake()
    {
        instance = this;
    }

    private const int COIN_START_VALUE = 10;
    private int currentCoinValue;

    void Start()
    {
        currentCoinValue = COIN_START_VALUE;
        gameObject.GetComponent<TextMeshProUGUI>().text = currentCoinValue.ToString();
    }

    public bool buy(int price)
    {
        if(currentCoinValue >= price)
        {
            currentCoinValue -= price;
            gameObject.GetComponent<TextMeshProUGUI>().text = currentCoinValue.ToString();
            return true;
        }

        return false;
    }

    public void sell(int price)
    {
        currentCoinValue += price;
        gameObject.GetComponent<TextMeshProUGUI>().text = currentCoinValue.ToString();
    }
}
