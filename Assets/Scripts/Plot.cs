using UnityEngine;
using System;

[Serializable] public class Plot : MonoBehaviour {
	public PlotState CurrentState;
	public Building SelectedBuilding;
	public float TimeLeftInSeconds;
	
	public void BuildBuilding(GameObject prefab) {
		SelectedBuilding = prefab.GetComponentInChildren<Building>();
		TimeLeftInSeconds = SelectedBuilding.TimeToBuildInMinutes * 60;
	}

	public void ActivateBuilding() {
	}

}

public enum ProfessionType {
	WoodCutting,
	Shopping,
	Fishing
}

public enum PlotState {
	Nothing,
	CurrentlyBuilding,
	BuiltOn,
	Unlocked
}