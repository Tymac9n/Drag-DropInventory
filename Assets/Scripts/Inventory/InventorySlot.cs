using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{
    [SerializeField] private GameItems items;
    [SerializeField] public Image Image;
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private int itemID;
    [SerializeField] private ItemType type;


    public override int? GetID()
    {
        return itemID;
    }

    public void FillByID(int ID)
    {
        var item = items.GetItemByID(ID);
        if (item == null) return;
        type = item.Type;
        title.text = item.Name;
        description.text = item.Description;
        Image.sprite = item.Image;
        itemID = ID;
    }
    
    public ItemType GetType( )
    {
        return type;
    }

}
