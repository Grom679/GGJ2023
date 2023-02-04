using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Helper;

public class ShopItemView : MonoBehaviour
{
    public Action OnBoughtAction;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    [Header("Debug")] 
    [SerializeField] private ShopItem _item;

    private void Awake()
    {
        _buyButton.onClick.AddListener(() => OnButtonClicked(_item, this));
        OnBoughtAction += OnBought;
    }

    private void OnDestroy()
    {
        OnBoughtAction -= OnBought;
    }

    private void OnBought()
    {
        Destroy(gameObject);
    }

    private void OnButtonClicked(ShopItem item, ShopItemView view)
    {
        ShopPanel.OnItemOpened?.Invoke(item, view);
    }
    public void InitItem(ShopItem item)
    {
        _item = item;
        _icon.sprite = Helpers.CreateSprite(_item.image);
    }
   
    
}
