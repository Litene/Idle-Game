using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustInteract : Interactable
{
    public override void Use() {
        Destroy(gameObject);
    }
}
