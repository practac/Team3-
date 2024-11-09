using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // 인벤토리에 들어갈 아이템 목록
    public GameObject inventoryPanel; // 인벤토리를 표시할 패널
    public GameObject inventorySlotPrefab; // 아이템 슬롯 프리팹
    private bool isInventoryOpen = false; // 인벤토리 패널이 열려 있는지 여부

    void Start()
    {
        inventoryPanel.SetActive(isInventoryOpen); // 인벤토리 패널 초기 상태
        // UpdateInventoryUI()를 여기서 호출하지 않음
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1번 키가 눌리면
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // 상태를 반전
        inventoryPanel.SetActive(isInventoryOpen); // 패널을 활성화/비활성화
    }

    public void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            items.Add(newItem);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        // 기존 아이템 슬롯 삭제
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // 새로운 아이템 슬롯 추가
        foreach (Item item in items)
        {
            if (item != null) // 아이템이 있는 경우에만 슬롯 생성
            {
                GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel.transform);
                Image icon = slot.transform.GetChild(0).GetComponent<Image>(); // 슬롯의 첫번째 자식은 아이콘 이미지
                icon.sprite = item.itemIcon; // 아이템의 아이콘을 슬롯에 설정
            }
        }
    }
}
