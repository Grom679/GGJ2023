using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Helper;

public class ShopPanel : MonoBehaviour
{
    public static Action<ShopItem, ShopItemView> OnItemOpened;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private RectTransform _shopItemsContent;
    [SerializeField] private ShopConfig _investmentsConfig;
    [SerializeField] private TMP_Text _coins;
    
    [Header("SelectedObject")] [SerializeField]
    private GameObject _selectedObject;

    [SerializeField] private Image _itemIcon;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemInfo;
    [SerializeField] private TextMeshProUGUI _itemCost;

    [Header("Debug")] 
    [SerializeField] private ShopItem _selectedShopItem;
    [SerializeField] private ShopItemView _view;
    private Dictionary<ShopItem, ShopItemView> _items;

    
    private bool _isAvailable;

    private void Awake()
    {
        _buyButton.onClick.AddListener(BuyItem);
        OnItemOpened += SelectObject;
        OpenShopPanel();
    }

    private void Start()
    {
        _coins.text = Global.Instance.Money.ToString();
    }

    private void OnDestroy()
    {
        OnItemOpened -= SelectObject;
    }

    private void OpenShopPanel()
    {
        _items = new Dictionary<ShopItem, ShopItemView>();
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
            if (!item.isBought)
            {
                GameObject itemViewObj = Instantiate(_shopItemPrefab, _shopItemsContent);
                ShopItemView itemView = itemViewObj.GetComponent<ShopItemView>();
                _items.Add(item, itemView);
                itemView.InitItem(item);
            }
        }
    }

    private void SelectObject(ShopItem item, ShopItemView view)
    {
        _view = view;
        _selectedShopItem = item;
        _selectedObject.SetActive(true);
        _itemIcon.sprite = Helpers.CreateSprite(item.image);
        _itemName.text = item.title;
        _itemInfo.text = item.info;
        _itemCost.text = item.price.ToString();
        _buyButton.interactable = CheckBuyState(item);
    }

    private void BuyItem()
    {
        _view.OnBoughtAction?.Invoke();
        _selectedShopItem.isBought = true;
        Global.Instance.Money -= _selectedShopItem.price;
        _coins.text = Global.Instance.Money.ToString();
        _selectedObject.SetActive(false);
    }

    private bool CheckBuyState(ShopItem item)
    {
        _isAvailable = Global.Instance.Money > item.price;
        return _isAvailable;
    }
}
