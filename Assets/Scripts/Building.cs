using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour {
	public List<Quest> Quests = new List<Quest>();
	public List<Upgrade> Upgrades = new List<Upgrade>();
	public ProfessionType ProfessionType;
	public float TimeToBuildInMinutes;
	
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
				if (GameManager.Instance.CityGold.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.Instance.CityGold.IncreaseMultiplier(Multiplier);
						Unlocked = true;
						return true;
					}

					UnlockEvent?.Invoke();
					Unlocked = true;
					return true;
				}

				break;
			case CurrencyType.Wood:
				if (GameManager.Instance.CityWood.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.Instance.CityWood.IncreaseMultiplier(Multiplier);
						Unlocked = true;
						return true;
					}

					UnlockEvent?.Invoke();
					Unlocked = true;
					return true;
				}

				break;
			case CurrencyType.Ore:
				if (GameManager.Instance.CityOre.ChangeValue(-CostAmount)) {
					//success
					if (UpgradeType == UpgradeType.Multiplier) {
						GameManager.Instance.CityOre.IncreaseMultiplier(Multiplier);
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
				CostAmount = GameManager.Instance.CityGold.CalculateCostBasedOnTime(CostTime);
				break;
			case CurrencyType.Wood:
				CostAmount = GameManager.Instance.CityWood.CalculateCostBasedOnTime(CostTime);
				break;
			case CurrencyType.Ore:
				CostAmount = GameManager.Instance.CityOre.CalculateCostBasedOnTime(CostTime);
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