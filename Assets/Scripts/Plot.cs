using UnityEngine;
using System;

[Serializable] public class Plot : MonoBehaviour {
	public PlotState CurrentState;
	public Building SelectedBuilding;
	
}

public enum ProfessionType {
	WoodCutting, Shopping, Fishing
}

public enum PlotState {
	Nothing, BuiltOn, Unlocked
}