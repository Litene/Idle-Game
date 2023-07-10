using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustInteract : Interactable
{
    public override void Use() {
        GameManager.instance.CityGold.ChangeValue(10);
        Destroy(gameObject);
    }
}
