using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Currency {
    private double _currentAmount;
    private bool _useDecimalFormat;
    public double CurrentCurrencyMultiplier { get; set; }
    public double CurrencyPerSecond { get; set; }

    private ValuePair[] CurrentValues = new[] {
        new ValuePair() {
            Multiplier = Multiplier.None,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Thousand,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Million,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Billion,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Trillion,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Quadrillion,
            CurrentValue = 0
        },
        new ValuePair() {
            Multiplier = Multiplier.Sextillion,
            CurrentValue = 0
        }
    };
    
    

    public double IncreaseMultiplier(float multiplier) {
        CurrencyPerSecond *= multiplier;
        CurrentCurrencyMultiplier *= multiplier;
        return CurrencyPerSecond;
    }


    public CurrencyType CurrencyType { get; private set; }


    

    public Currency(CurrencyType type) {
        CurrencyType = type;
        _currentAmount = 0;
        _useDecimalFormat = false;
        CurrentCurrencyMultiplier = 1;
        CurrencyPerSecond = 0;
    }

}

struct ValuePair {
    public Multiplier Multiplier;
    public int CurrentValue;
}


public enum CurrencyType {
    Wood,
    Ore,
    Gold
}

public enum Multiplier {
    None = 0,
    Thousand = 1,
    Million = 2,
    Billion = 3,
    Trillion = 4,
    Quadrillion = 5,
    Sextillion = 6
}