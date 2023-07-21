using System;
using UnityEngine;

[Serializable] public class Villager {
	private string _displayName;
	private GameObject _displayImage;
	public Villager (string displayName) {
		_displayName = displayName;
	}
}