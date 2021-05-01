using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemViews : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _name;
    [SerializeField] private Text _count;

    public string Name
    {
        set => _name.text = value;
    }
    public Sprite Icon
    {
        set
        {
            _icon.sprite = value;
            _icon.preserveAspect = true;
        }
        
    }
    public int Count 
    {
        set
        {
            if (value > 1)
            {
                _count.text = value.ToString();
            }
        }
    }
}
 