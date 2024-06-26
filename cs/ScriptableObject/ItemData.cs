using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType
{
    Hp,
    Mp
}

public enum EquipableType
{
    Atk,
    Def
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType Type;
    public float value;
}

[Serializable]
public class ItemDataEquipable
{
    public EquipableType Type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public int buyPrice;
    public ItemType type;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equipable")]
    public ItemDataEquipable[] equipables;
}
