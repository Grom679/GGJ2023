using System;
using System.Collections;
using System.Collections.Generic;
using Helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public static Action<ShopItem, InventoryItem> OnItemOpened;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private RectTransform _shopItemsContent;
    [SerializeField] private ShopConfig _investmentsConfig;
    
    [Header("SelectedObject")] [SerializeField]
    private GameObject _selectedObject;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Button _selectButton;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemInfo;

    [Header("Debug")] 
    [SerializeField] private ShopItem _selectedShopItem;
    private Dictionary<ShopItem, InventoryItem> _items;

    
    private bool _isAvailable;

    private void Awake()
    {
        _selectButton.onClick.AddListener(() => SelectItem(_selectedShopItem));
        OnItemOpened += SelectObject;
        OpenShopPanel();
    }

    private void OnDestroy()
    {
        OnItemOpened -= SelectObject;
    }

    private void OpenShopPanel()
    {
        _items = new Dictionary<ShopItem, InventoryItem>();
        _investmentsConfig = Global.Instance._shopConfig;
        InitializeItems();
    }

    private void InitializeItems()
    {
        ShopItem[] items = _investmentsConfig.ItemsData;
        int count = items.Length;
        for (int iItem = 0; iItem < count; ++iItem)
        {
            ShopItem item = items[iItem];
            if (item.isBought)
            {
                if (item.isSelected)
                {
                    Global.Instance._selectedItem = item;
                }
                GameObject itemViewObj = Instantiate(_shopItemPrefab, _shopItemsContent);
                InventoryItem itemView = itemViewObj.GetComponent<InventoryItem>();
                _items.Add(item, itemView);
                itemView.InitItem(item);
            }
        }
    }

    private void SelectObject(ShopItem item, InventoryItem view)
    {
        _selectedShopItem = item;
        _selectedObject.SetActive(true);
        _itemIcon.sprite = Helpers.CreateSprite(item.image);
        _itemName.text = item.title;
        _itemInfo.text = item.info;
    }

    private void SelectItem(ShopItem item)
    {
        InventoryItem.OnSelectAction?.Invoke(item);
        _selectedObject.SetActive(false);
        Global.Instance._selectedItem = item;
    }

}
