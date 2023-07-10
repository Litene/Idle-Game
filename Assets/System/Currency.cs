using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Currency {
    private double _currentAmount;

    private List<KeyValuePair<string, ulong>> NumberMultipliers = new List<KeyValuePair<string, ulong>>() {
        new KeyValuePair<string, ulong>("Quintillion", 1000000000000000000),
        new KeyValuePair<string, ulong>("Quadrillion", 1000000000000000),
        new KeyValuePair<string, ulong>("Trillion", 1000000000000),
        new KeyValuePair<string, ulong>("Billion", 1000000000),
        new KeyValuePair<string, ulong>("Million", 1000000),
        new KeyValuePair<string, ulong>("Thousand", 1000),
    };

    public double CurrentCurrencyMultiplier { get; set; }
    public double CurrencyPerSecond { get; set; }


    public double IncreaseMultiplier(float multiplier) {
        CurrencyPerSecond *= multiplier;
        CurrentCurrencyMultiplier *= multiplier;
        return CurrencyPerSecond;
    }

    public bool ChangeValue(double changeAmount) {
        if (changeAmount < 0) {
            if (_currentAmount + changeAmount > 0) {
                _currentAmount += changeAmount;
                return true;
            }
        }
        else {
            _currentAmount += changeAmount;
            return true;
        }

        return false;
    }

    public CurrencyType CurrencyType { get; private set; }

    public override string ToString() {
        ulong currentAmount = 0;
        string currentLargestNumber = "";
        foreach (var multiplier in NumberMultipliers) {
            if ((double)(_currentAmount / multiplier.Value) >= 1) {
                if (currentLargestNumber == "") {
                    currentLargestNumber = multiplier.Key;
                    return (_currentAmount / multiplier.Value).ToString("0.##") + " " + currentLargestNumber;
                }
            }
        }
        return Math.Round(_currentAmount).ToString(CultureInfo.InvariantCulture);
    }

    public Currency(CurrencyType type) {
        CurrencyType = type;
        _currentAmount = 0;
        CurrentCurrencyMultiplier = 1;
        CurrencyPerSecond = 0;
    }

    public void IncreasePerSecond(float deltaTime) {
        _currentAmount += deltaTime * CurrentCurrencyMultiplier * CurrencyPerSecond;
    }
}


public enum CurrencyType {
    Wood,
    Ore,
    Gold
}