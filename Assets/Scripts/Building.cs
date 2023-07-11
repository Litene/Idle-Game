using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour {
	public List<Quest> Quests = new List<Quest>();
	public List<Upgrade> Upgrades = new List<Upgrade>();

	private void Awake() {
		foreach (var quest in Quests) {
			quest.InitializeQuest();
		}

		foreach (var upgrade in Upgrades) {
			upgrade.Initialize();
		}
	}

	public void UnlockUpgrade(string questToUnlock) {
		foreach (var upgrade in Upgrades) {
			if (upgrade.UpgradeName == questToUnlock) {
				if (!upgrade.Unlocked) {
					upgrade.TryUnlock();
				}
			}
		}
	}

	private void Update() {
		// this is expensive.
		foreach (var upgrade in Upgrades) {
			upgrade.Update();
		}
	}
}

[System.Serializable]
public class Upgrade {
	public string UpgradeName;
	public UpgradeType UpgradeType;
	public UnityEvent UnlockEvent;
	public CostType CostType;
	public double CostAmount;
	public int CostTime;
	public CurrencyType CurrencyType;
	public float Multiplier;
	public bool Unlocked;

	public void Initialize() {
	}

	public void Update() {
		SetDurationCost();
	}

	public bool TryUnlock() {
		switch (CurrencyType) {
			case CurrencyType.Gold:
				if (GameManager.instance.CityGold.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.instance.CityGold.IncreaseMultiplier(Multiplier);
						Unlocked = true;
						return true;
					}

					UnlockEvent?.Invoke();
					Unlocked = true;
					return true;
				}

				break;
			case CurrencyType.Wood:
				if (GameManager.instance.CityWood.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.instance.CityWood.IncreaseMultiplier(Multiplier);
						Unlocked = true;
						return true;
					}

					UnlockEvent?.Invoke();
					Unlocked = true;
					return true;
				}

				break;
			case CurrencyType.Ore:
				if (GameManager.instance.CityOre.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.instance.CityOre.IncreaseMultiplier(Multiplier);
						Unlocked = true;
						return true;
					}

					UnlockEvent?.Invoke();
					Unlocked = true;
					return true;
				}

				break;
		}

		return false;
	}

	private void SetDurationCost() {
		if (CostType == CostType.SetCost) {
			return;
		}

		switch (CurrencyType) {
			case CurrencyType.Gold:
				CostAmount = GameManager.instance.CityGold.CalculateCostBasedOnTime(CostTime);
				break;
			case CurrencyType.Wood:
				CostAmount = GameManager.instance.CityWood.CalculateCostBasedOnTime(CostTime);
				break;
			case CurrencyType.Ore:
				CostAmount = GameManager.instance.CityOre.CalculateCostBasedOnTime(CostTime);
				break;
		}
	}
}

[System.Serializable]
public enum UpgradeType {
	Unlock,
	Multiplier
}

[System.Serializable]
public enum CostType {
	Duration,
	SetCost
}