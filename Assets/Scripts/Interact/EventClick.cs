using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Interactable _interactable;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _interactable = GetComponent<Interactable>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _interactable.Use();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _spriteRenderer.sprite = _interactable.hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _spriteRenderer.sprite = _interactable.baseSprite;
    }
}
