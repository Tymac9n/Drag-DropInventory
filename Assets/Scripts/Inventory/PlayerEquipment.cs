﻿using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private PlayerItems playerItems;
    [SerializeField] public GameObject DragPrefab;
    [SerializeField] public Image dragPrefabImage;

    public void Awake()
    {
        ImagesLoader.LoadImages();
        //foreach (RectTransform child in gameObject.transform)
        //{
        //    child.GetComponent<PlayerEquipmentSlot>().FillSlot(child.GetSiblingIndex());
        //}
    }

    public void ShowInfo() // выводит все слоты экипировки героя с индексом предметов
    {
        foreach (RectTransform child in gameObject.transform)
        {
            child.GetComponent<PlayerEquipmentSlot>().ShowSlotInfo();
        }
    }
}