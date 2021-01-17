using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private int itemIndex;

    public virtual int? GetIndex()
    {
        return itemIndex;
    }
}
