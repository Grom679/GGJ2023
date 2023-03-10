using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance;
    public long money = 100000;
    public ShopConfig _shopConfig;
    public ShopItem _selectedItem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        InitializeItems();
    }
    
    private void InitializeItems()
    {
        ShopItem[] items = _shopConfig.ItemsData;
        int count = items.Length;
        for (int iItem = 0; iItem < count; ++iItem)
        {
            ShopItem item = items[iItem];
            if (item.isSelected)
            {
                _selectedItem = item;
            }
        }
    }
}
