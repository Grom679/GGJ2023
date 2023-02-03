using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "ScriptableObjects/ShopConfig")]
public class ShopConfig : ScriptableObject
{
    [SerializeField]
    private ShopItem[] _itemsData;
    
    public ShopItem[] ItemsData
    {
        get => _itemsData;
        protected set => _itemsData = value;
    }
}
