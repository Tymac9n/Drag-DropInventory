using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySlot : ItemSlot
{
    [SerializeField] private GameItems allItems;
    [SerializeField] private PlayerInventoryItems inventoryItems;
    [SerializeField] public Image Image;
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private Text countText;
    [SerializeField] private int count;
    [SerializeField] private int itemID;
    [SerializeField] private ItemType type;

    public override int? GetID()
    {
        return itemID;
    }

    public void FillByID(int ID)
    {
        var item = allItems.GetItemByID(ID);
        if (item == null) return;
        type = item.Type;
        title.text = item.Name;
        description.text = item.Description;
        Image.sprite = item.Image;
        itemID = ID;
    }

    public void SetCount(int amount)
    {
        count = amount;
        if (count > 1) ShowCount();
        countText.text = count.ToString();
    }

    public void IncrementCount()
    {
        count++;
        if (count > 1) ShowCount();
        countText.text = count.ToString();
    }

    public void DecrementCount()
    {
        count--;
        inventoryItems.DecreaseItem(itemID);
        if (count < 1)
        {
            Destroy(gameObject);
            return;
        }
        countText.text = count.ToString();
        if (count < 2) HideCount();
    }

    public ItemType GetType()
    {
        return type;
    }

    private void ShowCount()
    {
        countText.enabled = true;
    }

    private void HideCount()
    {
        countText.enabled = false;
    }
}
