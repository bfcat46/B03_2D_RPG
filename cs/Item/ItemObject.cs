using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnInteract();
    }

    public void OnInteract()
    {
        CharacterManager_KYJ.Instance.Player.itemData = data;
        CharacterManager_KYJ.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
