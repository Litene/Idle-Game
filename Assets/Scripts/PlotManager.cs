using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlotManager : MonoBehaviour {
	public List<Plot> NothingPlots = new List<Plot>();
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