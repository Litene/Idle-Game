using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcuttingInteract : Interactable {
    public WoodCutterPopup woodCutterPopup;
    
    public override void Use() {
        woodCutterPopup.ChopTrunk();

        GetComponent<SpriteRenderer>().sprite = baseSprite;
    }
}
