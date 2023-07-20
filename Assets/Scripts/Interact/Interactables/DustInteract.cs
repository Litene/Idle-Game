using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustInteract : Interactable {

    public GameObject poofParticle;
    public override void Use() {
        GameObject newPoof = Instantiate(poofParticle, transform.position, Quaternion.identity);
        Destroy(newPoof, 1f);
        GameManager.Instance.CityGold.ChangeValue(10);
        Destroy(gameObject);
    }

    private void Awake() {
        base.Initialize();
    }
}