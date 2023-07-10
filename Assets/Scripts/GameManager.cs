using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour {
    private GameManager _instance;
    public List<IModelListener> Listeners { get; set; }

    public GameManager Instance {
        get {
            if (_instance == null) _instance = this;

            return _instance;
        }
    }
    public Currency CityGold { get; private set; } = new Currency(CurrencyType.Gold);
    public Currency CityLumber { get; private set; } = new Currency(CurrencyType.Wood);
    public Currency CityWood { get; private set; } = new Currency(CurrencyType.Ore);

    public void Update() {
        UpdateIncome();
        if (Input.GetKeyDown(KeyCode.Space)) {
            CityGold.IncreaseAmount(600f);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) {
            CityGold.DecreaseAmount(3.0f);
        }
        Debug.Log(CityGold);
    }

    private void UpdateIncome() {
        CityGold.IncreasePerSecond(Time.deltaTime);
        CityLumber.IncreasePerSecond(Time.deltaTime);
        CityWood.IncreasePerSecond(Time.deltaTime);
    }
}

public enum GameState {
    Running, Paused, UnSelected
}