using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemControler : MonoBehaviour
{
    [SerializeField] private InventoryItem _data;
    [SerializeField] private InventoryItemViews _view;

    public void Start()
    {
        _view.Description = _data.Name;
        _view.Icon = _data.Texture;
    }
}
