using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DustKillzone : MonoBehaviour {
    public DustSpawner _dustSpawner;

    private void Update() {
        if (transform.position.x > _dustSpawner.killValue) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        _dustSpawner.activeDustBunnies.Remove(gameObject);
        if (_dustSpawner.hasVacuum) {
            GameManager.instance.CityGold.ChangeValue(10);
        }
    }
}
