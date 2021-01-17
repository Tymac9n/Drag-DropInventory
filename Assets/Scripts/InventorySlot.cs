using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{
    [SerializeField] private GameItems items;
    [SerializeField] public Image Image;
    [SerializeField] private Text Title;
    [SerializeField] private Text Description;
    [SerializeField] private int itemIndex;
    [SerializeField] private ItemType type;

    public override int? GetIndex()
    {
        return itemIndex;
    }

    public void FillFromIndex(int index)
    {
        var item = items.GetItemByID(index);
        if (item == null) return;
        type = item.Type;
        Title.text = item.Name;
        Description.text = item.Description;
        Image.sprite = item.Image;
        itemIndex = index;
    }
    public ItemType GetType( )
    {
        return type;
    }
}
