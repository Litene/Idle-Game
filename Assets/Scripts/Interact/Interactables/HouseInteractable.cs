using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HouseInteractable : Interactable {
    public GameObject housePopup;
    public UnityEvent OnOpenEvent;
    public UnityEvent OnCloseEvent;
    public override void Use() {
        // if (!(housePopup.transform.localScale == _hiddenScale)) {
        //     _popupManager.CloseAllLeftPopups();
        // }
        ToggleHidden();
        //housePopup.SetActive(!housePopup.activeSelf);
    }
    
    public Vector3 _hiddenScale = new Vector3(0, 0, 0);
    public Vector3 _normalScale;

    void ToggleHidden() {
      
        if (housePopup.transform.localScale == _hiddenScale) {
          
            housePopup.transform.localScale = _normalScale;
            OnOpenEvent?.Invoke();
        }
        else {
           
            housePopup.transform.localScale = _hiddenScale;
            OnCloseEvent?.Invoke();
        }
    }
    private void Awake() {
        base.Initialize();
        _normalScale = housePopup.transform.localScale;
    }
}