using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
    IPointerEnterHandler, IPointerExitHandler, IEventHandler {
    private Interactable _interactable;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private ToolTip toolTip;

    private void Awake() {
        _interactable = GetComponent<Interactable>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData) {
    }

    public void OnPointerUp(PointerEventData eventData) {
    }

    public void OnPointerClick(PointerEventData eventData) {
        Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
        if (colliderHit) {
            foreach (var listener in Listeners) {
                listener.OnClicked(colliderHit.gameObject);
            }
            
            _interactable.Use();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (_interactable.hoverSprite == null) {
            return;
        }
        _spriteRenderer.sprite = _interactable.hoverSprite;

        if (toolTip.toolTipPrefab != null) {
            toolTip.ToggleTooltip(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (_interactable.baseSprite == null) {
            return;
        }
        _spriteRenderer.sprite = _interactable.baseSprite;
        
        if (toolTip.toolTipPrefab != null) {
            toolTip.ToggleTooltip(true);
        }
    }

    public List<IEventListener> Listeners { get; set; } = new List<IEventListener>();
    public IEventHandler RegisterListener(IEventListener listener) {
        Listeners.Add(listener);
        return this;
    }

    public void SetNewTooltip(string newText) {
        toolTip.UpdateTooltipText(newText);
    }
}