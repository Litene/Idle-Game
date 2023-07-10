using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DustKillzone : MonoBehaviour {
    public DustSpawner _dustSpawner;
    
    private void Update() {
        if (transform.position.x > -2.4f) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        _dustSpawner.activeDustBunnies.Remove(gameObject);
    }
}
