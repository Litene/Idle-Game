using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Currency {
    public Multiplier CurrentMultiPlier;
    public float CurrentAmount;
    public CurrencyType CurrencyType;
    
    public override string ToString() {
        return CurrentAmount.ToString();
    }
}




public enum CurrencyType {
    Wood,
    Ore,
    Gold
}

public enum Multiplier {
    Million = 7,
    Billion = 10,
    Trillion = 13,
    Quadrillion = 16,
    Sextillion = 19
}