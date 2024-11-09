using UnityEngine;
using UnityEngine.EventSystems;

public class DragandPrint : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    private RectTransform rectTransform;
    public RectTransform otherImage; // Reference to the other image UI
    public GameObject collisionImage; // Image to display on collision
    private bool isCollisionImageVisible = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (collisionImage != null)
        {
            collisionImage.SetActive(false); // Ensure the image is hidden initially
        }
    }

    void Update()
    {
        // Check for space key press to hide the image
        if (isCollisionImageVisible && Input.GetKeyDown(KeyCode.Space))
        {
            collisionImage.SetActive(false);
            isCollisionImageVisible = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out pos);
        rectTransform.anchoredPosition = pos;

        // Check for collision with the other image
        if (IsOverlapping(rectTransform, otherImage))
        {
            ShowCollisionImage();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = DefaultPos;
    }

    bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        Rect rect1World = new Rect(
            rect1.position.x - rect1.rect.width * rect1.pivot.x,
            rect1.position.y - rect1.rect.height * rect1.pivot.y,
            rect1.rect.width,
            rect1.rect.height
        );

        Rect rect2World = new Rect(
            rect2.position.x - rect2.rect.width * rect2.pivot.x,
            rect2.position.y - rect2.rect.height * rect2.pivot.y,
            rect2.rect.width,
            rect2.rect.height
        );

        return rect1World.Overlaps(rect2World);
    }

    void ShowCollisionImage()
    {
        if (collisionImage != null)
        {
            collisionImage.SetActive(true);
            isCollisionImageVisible = true;
        }
    }
}
