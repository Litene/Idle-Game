using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlotManager : MonoBehaviour {
	public List<Plot> NothingPlots = new List<Plot>();
	public List<Plot> CurrentBuildingPlots = new List<Plot>();
	public List<Plot> BuiltOnPlots = new List<Plot>();
	public List<Plot> UnlockedPlots = new List<Plot>();

	public Plot GetEmptyCorrectPlot(Villager villager) {
		foreach (var plot in BuiltOnPlots) {
			if (villager.Profession == plot.SelectedBuilding.ProfessionType) {
				return plot;
			}
		}

		return null;
	}

	private void Update() {
		UpdatePlotBuildTimers();
	}
	private void UpdatePlotBuildTimers() {
		List<Plot> plotsToMoveFromNothing = new List<Plot>();
		foreach (var plot in NothingPlots) {
			if (!plot) {
				continue;
			}
			if (plot.CurrentState == PlotState.CurrentlyBuilding) {
				plotsToMoveFromNothing.Add(plot);
				CurrentBuildingPlots.Add(plot);
			}
		}

		foreach (var removedPlot in plotsToMoveFromNothing) {
			NothingPlots.Remove(removedPlot);
		}

		
		List<Plot> plotsToMoveFromBuilding = new List<Plot>();
		foreach (var buildingPlot in CurrentBuildingPlots) {
			buildingPlot.TimeLeftInSeconds -= Time.deltaTime;
			if (buildingPlot.TimeLeftInSeconds <= 0) {
				BuiltOnPlots.Add(buildingPlot);
				//buildingPlot.
			//	plotsToMoveFromBuilding.Add(buildingPlot);
			}
		}

		foreach (var plotsToRemove in plotsToMoveFromBuilding) {
			CurrentBuildingPlots.Remove(plotsToRemove);
		}
	}

	public void UnlockPlot(Plot plot) {
		Plot plotToRemove = null;
		foreach (var builtOnPlot in BuiltOnPlots) {
			if (plot.Equals(builtOnPlot)) {
				plotToRemove = builtOnPlot;
				UnlockedPlots.Add(builtOnPlot);
				builtOnPlot.SelectedBuilding.transform.position = builtOnPlot.transform.position;
				builtOnPlot.CurrentState = PlotState.Unlocked;
				//	builtOnPlot.SelectedBuilding.
			}
		}

		BuiltOnPlots.Remove(plotToRemove);
		
		
	}
}