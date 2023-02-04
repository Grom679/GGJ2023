using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
    public static Action OnShopOpened;
    [SerializeField] private GameObject _hintPanel;
    [SerializeField] private GameObject _shopPanelPrefab;
    private GameObject _shopPanel;
    private bool _isOpened = false; 

    private void ShopInteract()
    {
        Debug.LogError("shopInteract");
        if (_isOpened)
        {
            _isOpened = false;
            if (_shopPanel != null)
            {
                Destroy(_shopPanel);
            }
        }
        else
        {
            _isOpened = true;
            _shopPanel = Instantiate(_shopPanelPrefab);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _hintPanel.SetActive(true);
            OnShopOpened += ShopInteract;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _hintPanel.SetActive(false);
            OnShopOpened -= ShopInteract;
            if (_shopPanel != null)
            {
                _isOpened = false;
                Destroy(_shopPanel);
            }
        }
    }
}
