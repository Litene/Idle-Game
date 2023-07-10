using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInteractable : Interactable {
    [SerializeField] private GameObject objectToClose;
    
    public override void Use() {
        objectToClose.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = baseSprite;
    }
}
