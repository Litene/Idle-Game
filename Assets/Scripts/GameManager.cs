using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [field: SerializeField] public Currency CityGold = new Currency() { CurrencyType = CurrencyType.Gold };
    [field: SerializeField] public Currency CityLumber = new Currency() { CurrencyType = CurrencyType.Wood };
    [field: SerializeField] public Currency CityOre = new Currency() { CurrencyType = CurrencyType.Ore };

    public float CityGoldPerSecond { get; private set; } = 10;
    public float CityLumberPerSecond { get; private set; } = 0;
    public float CityOrePerSecond { get; private set; } = 0;

    [field: SerializeField] public uint CurrentGold;

    // private ulong _cityGoldPerFrame;
    // private ulong _goldPerFrame;
    // private ulong _goldPerFrame;
    public void Update() {
        CityGold.CurrentAmount += (CityGoldPerSecond * Time.deltaTime);
        //CityLumber += (CityLumberPerSecond * Time.deltaTime);
        // CityOre += (CityOrePerSecond * Time.deltaTime);
        // CurrentGold = (uint)CityGold;
    }
}