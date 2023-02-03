using System;
using System.Collections;
using System.Collections.Generic;
using Helper;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public static Action<ShopItem> OnSelectAction;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _iconSelected;
    [SerializeField] private Button _selectButton;
    
    [Header("Debug")] 
    [SerializeField] private ShopItem _item;

    private void Awake()
    {
        _selectButton.onClick.AddListener(() => OnSelectClicked(_item, this));
        OnSelectAction += OnSelect;
    }

    private void OnDestroy()
    {
        OnSelectAction -= OnSelect;
    }

    private void OnSelect(ShopItem item)
    {
        if (_item == item)
        {
            _iconSelected.gameObject.SetActive(true);
            _item.isSelected = true;
        }
        else
        {
            _iconSelected.gameObject.SetActive(false);
            _item.isSelected = false;
        }
    }

    private void OnSelectClicked(ShopItem item, InventoryItem view)
    {
        InventoryPanel.OnItemOpened?.Invoke(item, view);
    }
    public void InitItem(ShopItem item)
    {
        _item = item;
        _icon.sprite = Helpers.CreateSprite(_item.image);
        OnSelect(Global.Instance._selectedItem);
    }
}
