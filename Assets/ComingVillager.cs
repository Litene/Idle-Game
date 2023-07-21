using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ComingVillager : MonoBehaviour {
	public List<KeyValuePair<float, Villager>> VillagersApproaching;
	public List<Villager> PossibleVillagers; // fill in inspector
	public List<Villager> ArrivedVillagers;
	
	private void Awake() { // probably not 
		PossibleVillagers.Add(new Villager("Janus"));
		PossibleVillagers.Add(new Villager("Eve"));
		PossibleVillagers.Add(new Villager("Majkel"));
		PossibleVillagers.Add(new Villager("Radnus"));
	}

	void AddIncomingVillagers(float timeInMinutes, string villagerName = "") =>
		VillagersApproaching.Add(new KeyValuePair<float, Villager>(timeInMinutes, new Villager(villagerName)));
	

	void AddArrivedVillagers() {
		List<KeyValuePair<float, Villager>> indexesToRemove = new List<KeyValuePair<float, Villager>>();
		foreach (var timerAndVillager in VillagersApproaching) {
			if (timerAndVillager.Key <= 0) {
				ArrivedVillagers.Add(timerAndVillager.Value);
				indexesToRemove.Add(timerAndVillager);
			}
		}

		foreach (var kVpToRemove in indexesToRemove) {
			VillagersApproaching.Remove(kVpToRemove);
		}
	}
	
	
	
}
