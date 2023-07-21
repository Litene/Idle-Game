using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using Random = UnityEngine.Random;

public class ComingVillager : MonoBehaviour {
	public List<VillagerTuple> VillagersApproaching = new List<VillagerTuple>();
	public List<Villager> PossibleVillagers; // fill in inspector
	public List<Villager> ArrivedVillagers;
	private bool _queueIsFull;

	private PlotManager _plotManager;
	void AddIncomingVillagers(float timeInMinutes = 2f, string villagerName = "", Villager villagerToAdd = null) {
		VillagersApproaching.Add(new VillagerTuple(AddVillager(villagerToAdd), timeInMinutes));
		
	}

	private void Awake() {
		_plotManager = FindObjectOfType<PlotManager>();
	}


	[ContextMenu("Add Random Villager")]
	void AddIncomingVillagers() {
		VillagersApproaching.Add(new VillagerTuple(AddVillager(null), 2f));
	}

	private Villager AddVillager(Villager villagerToAdd) =>
		villagerToAdd ? villagerToAdd : PossibleVillagers[Random.Range(0, PossibleVillagers.Count)];

	

	void AddArrivedVillagers() {
		if (_queueIsFull) return;
		
		List<VillagerTuple> indexesToRemove = new List<VillagerTuple>();
		foreach (var timerAndVillager in VillagersApproaching) {
			if (timerAndVillager.TimeRemainingInSeconds <= 0) {
				ArrivedVillagers.Add(timerAndVillager.Villager);
				indexesToRemove.Add(timerAndVillager);
				if (ArrivedVillagers.Count > 2) {
					_queueIsFull = true;
					//todo: add call to UI manager saying text that they are waiting
				}
			}
		}

		foreach (var kVpToRemove in indexesToRemove) {
			VillagersApproaching.Remove(kVpToRemove);
		}
	}

	void AcceptVillager(Villager villager) {
		if (_plotManager.GetEmptyCorrectPlot(villager) != null) {
			//_plotManager.UnlockPlot;
			//todo: unlockPlot
			return;
		}
		//todo: spawn text
	}

	void DeclineVillager() {
		
	}
	
	

	void UpdateTimers() {
		if (_queueIsFull) return;
		
		foreach (var villager in VillagersApproaching) {
			villager.TimeRemainingInSeconds -= Time.deltaTime;
		}
		AddArrivedVillagers();
	}
	
	private void Update() {
		UpdateTimers();
	}


}

[Serializable] public class VillagerTuple {
	public float TimeRemainingInSeconds;
	public Villager Villager;

	public VillagerTuple(Villager villager, float timeRemainingInMinutes) {
		TimeRemainingInSeconds = timeRemainingInMinutes * 60;
		Villager = villager;
	}
}