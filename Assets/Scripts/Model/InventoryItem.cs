using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Custom/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Texture;
    public ItemCategory Category; 
}

public enum ItemCategory
{
    Common,
    Keys,
    Weapon
}