using System;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public Sprite baseSprite;
    public Sprite hoverSprite;

    protected PopupManager _popupManager;
    
    public void Initialize() {
        _popupManager = FindObjectOfType<PopupManager>(); 
    }

    public virtual void Use() {
        Debug.Log("Interactable Clicked");
    }
}