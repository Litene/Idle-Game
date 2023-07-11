using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHousePopup : MonoBehaviour {
    [SerializeField] private GameObject vacuum;
    [SerializeField] private DustSpawner dustSpawner;
    private Vector3 _vacuumNormalScale;
    private void Awake() {
        _vacuumNormalScale = vacuum.transform.localScale;
    }

    public void HideDust() { // call from close
        dustSpawner.ShouldSpawnInvisible = true;
    }

    public void ShowDust() {
        dustSpawner.ShouldSpawnInvisible = false;
    }

    public void EnableVacuum() {
        vacuum.transform.localScale = _vacuumNormalScale;
        dustSpawner.killValue = -5f;
        dustSpawner.hasVacuum = true;
    }
}
