using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeInteractable : Interactable
{
    // Start is called before the first frame update
    public UnityEvent UnlockedEvent;
    public override void Use() {
        UnlockedEvent?.Invoke();
    }

    private void Awake() {
        base.Initialize();
    }
}
