using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HouseInteractable : Interactable {
    [SerializeField] private GameObject housePopup;

    public override void Use() {
        if (!housePopup.activeSelf) {
            _popupManager.CloseAllLeftPopups();
        }
        housePopup.SetActive(!housePopup.activeSelf);
    }
}