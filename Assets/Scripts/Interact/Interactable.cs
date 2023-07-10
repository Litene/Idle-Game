using System;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public Sprite baseSprite;
    public Sprite hoverSprite;

    protected PopupManager _popupManager;

    private void Awake() {
        _popupManager = FindObjectOfType<PopupManager>();
    }

    public virtual void Use() {
        Debug.Log("Interactable Clicked");
    }
}