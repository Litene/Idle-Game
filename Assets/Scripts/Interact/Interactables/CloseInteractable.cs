using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloseInteractable : Interactable {
    [SerializeField] private GameObject objectToClose;
    private Vector3 _hiddenScale = new Vector3(0, 0, 0);
    private Vector3 _normalScale;
    public UnityEvent ClosedEvent;

    void ToggleHidden() {
        if (objectToClose.transform.localScale == _hiddenScale) {
            objectToClose.transform.localScale = _normalScale;
        }
        else {
            objectToClose.transform.localScale = _hiddenScale;
            ClosedEvent?.Invoke();
        }
    }

    private void Awake() {
        base.Initialize();
    }

    private void Start() {
        _normalScale = objectToClose.transform.localScale;
    }

    public override void Use() {
        //objectToClose.SetActive(false);
        ToggleHidden();
        GetComponent<SpriteRenderer>().sprite = baseSprite;
    }
}
