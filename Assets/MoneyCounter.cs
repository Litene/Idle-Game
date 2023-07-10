using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour {
    public TMP_Text tmpRef;

    private void Update() {
        tmpRef.text = GameManager.instance.CityGold.ToString();
    }
}
