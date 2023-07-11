using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBuildingInteractable : Interactable {
    public Sprite newBaseSprite;
    public Sprite newHoveredSprite;

    public GameObject newPopUp;

    public HouseInteractable targetBuilding;

    public GameObject unlockPopup;

    public override void Use() {
        targetBuilding.baseSprite = newBaseSprite;
        targetBuilding.hoverSprite = newHoveredSprite;

        targetBuilding.housePopup = newPopUp;
        
        transform.localScale = Vector3.zero;

        targetBuilding.GetComponent<SpriteRenderer>().sprite = newBaseSprite;
        
        Destroy(unlockPopup);
    }
}
