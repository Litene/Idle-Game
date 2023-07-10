using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public List<IEventListener> Listeners { get; set; }

    /*public static GameManager Instance {
        get {
            if (_instance == null) _instance = this;

            return _instance;
        }
    }*/

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public Currency CityGold { get; private set; } = new Currency(CurrencyType.Gold);
    public Currency CityOre { get; private set; } = new Currency(CurrencyType.Wood);
    public Currency CityWood { get; private set; } = new Currency(CurrencyType.Ore);

    public void Update() {
        UpdateIncome();
    }

    private void UpdateIncome() {
        CityGold.IncreasePerSecond(Time.deltaTime);
        CityOre.IncreasePerSecond(Time.deltaTime);
        CityWood.IncreasePerSecond(Time.deltaTime);
    }
}

public enum GameState {
    Running, Paused, UnSelected
}