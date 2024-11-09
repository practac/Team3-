using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤 패턴으로 InventoryManager를 전역 접근 가능하게 설정
    public Image[] itemSlots; // 4개의 ItemSlot 이미지를 담을 배열

    private void Awake()
    {
        // 싱글톤 패턴 설정: InventoryManager 인스턴스가 하나만 존재하도록 보장
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 아이템을 슬롯에 추가하는 메서드
    public void AddItemToSlot(Sprite itemSprite)
    {
        // 각 슬롯을 순회하며 빈 슬롯을 찾음
        foreach (var slot in itemSlots)
        {
            if (slot.sprite == null) // 슬롯이 비어 있는지 확인
            {
                slot.sprite = itemSprite; // 아이템 이미지 할당
                break; // 첫 번째 빈 슬롯에만 할당하고 루프 종료
            }
        }
    }
}

