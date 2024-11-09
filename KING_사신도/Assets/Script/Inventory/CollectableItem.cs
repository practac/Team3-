using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectableItem : MonoBehaviour
{
    public Sprite itemSprite; // 이 아이템의 스프라이트 (아이템 이미지)

    private void OnMouseDown() // Collider 2D가 있는 오브젝트를 클릭할 때 호출됨
    {
        // InventoryManager의 AddItemToSlot 메서드를 호출하여 아이템을 인벤토리에 추가
        InventoryManager.Instance.AddItemToSlot(itemSprite);

        // 아이템을 획득한 후 사라지도록 비활성화 (또는 삭제)
        gameObject.SetActive(false);
    }
}

