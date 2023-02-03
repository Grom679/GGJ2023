using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ShopItemScriptableObject", menuName = "ScriptableObjects/ShopItem")]
public class ShopItem: ScriptableObject
{
    public string title;
    public string info;
    public bool isBought;
    public bool isSelected;
    public Texture2D image;
    public int price;
    public PlayerStatsType type;
    public float upgradeBonus;
}
