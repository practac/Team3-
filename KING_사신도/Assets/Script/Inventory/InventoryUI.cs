using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // 인벤토리 패널을 참조할 변수

    public void ToggleInventory()
    {
        // 인벤토리 패널의 활성화 상태를 토글합니다.
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}



