using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money_KYJ : MonoBehaviour
{
    public UIShop shopMoney;

    public GameObject openShopBtn;
    public GameObject openInventory;

    public TextMeshProUGUI goldTxt;

    public bool isCheck = false;

    public void AddScore()
    {
        shopMoney.gold += 10000;
        goldTxt.text = shopMoney.gold.ToString();
    }

    public void OnClickMoney()
    {
        AddScore();
    }

    public void OnClickShop()
    {
        if (isCheck == false)
        {
            openShopBtn.SetActive(true);
            isCheck = true;
        }
        else
        {
            openShopBtn.SetActive(false);
            isCheck = false;
        }
    }

    public void OnClickExit()
    {
        openShopBtn.SetActive(false);
        isCheck = false;
    }

    public void OnClickInventory()
    {
        if(isCheck == false)
        {
        openInventory.SetActive(true);
            isCheck = true;
        }
        else if(isCheck == true)
        {
            openInventory.SetActive(false);
            isCheck = false;
        }
    }
}
