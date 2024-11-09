using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public GameObject[] itemSlots; // 4개의 아이템 슬롯 배열

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItemToSlot(Sprite itemSprite)
    {
        foreach (var slot in itemSlots)
        {
            Image slotImage = slot.GetComponentInChildren<Image>();
            if (slotImage.sprite == null) // 슬롯이 비어있는지 확인
            {
                slotImage.sprite = itemSprite; // 아이템 이미지 할당
                break;
            }
        }
    }
}

