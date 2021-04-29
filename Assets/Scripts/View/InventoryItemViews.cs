using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemViews : MonoBehaviour
{
    internal Texture2D Icon;
    [SerializeField] private Image _icon;
    [SerializeField] private Text _description;

    public string Description
    {
        set => _description.text = value;
    }
}
 