using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    public ItemData item;

    public Button button;
    public Image icon;

    public UIShop shop;

    public int index;

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public void OnClickButton()
    {
        shop.ShopListItem(index);
    }
}
