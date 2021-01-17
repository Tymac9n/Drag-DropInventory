using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ID;
    public string Name;
    [SerializeField] private string imageName;
    public Sprite Image
    {
        get { return ImagesLoader.FindImage(imageName); }
    }
    public string Description;
    public ItemType Type;
    //public List<Attributes> Modifiers;
}

public enum ItemType
{
    Weapon,
    Armor,
    Artifact
}
