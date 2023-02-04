using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanelPrefab;
    private bool _isOpened = false;
    private GameObject _inventoryPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !PauseManager.Instance.IsPaused)
        {
           Debug.LogError("try to open Shop");
           ShopObject.OnShopOpened?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.I) && !PauseManager.Instance.IsPaused)
        {
            //ShopObject.OnShopOpened?.Invoke();
            InventoryInteract();
            Debug.LogError("try to open Collected");
        }
    }
    
    private void InventoryInteract()
    {
        Debug.LogError("shopInteract");
        if (_isOpened)
        {
            _isOpened = false;
            if (_inventoryPanel != null)
            {
                Destroy(_inventoryPanel);
            }
        }
        else
        {
            _isOpened = true;
            _inventoryPanel = Instantiate(_inventoryPanelPrefab);
        }
    }
}
