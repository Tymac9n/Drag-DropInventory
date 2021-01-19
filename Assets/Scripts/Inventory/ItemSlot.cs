using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private int itemID;

    public virtual int? GetID()
    {
        return itemID;
    }
}
