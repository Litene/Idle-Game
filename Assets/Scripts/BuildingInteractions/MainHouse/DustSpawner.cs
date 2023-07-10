using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DustSpawner : MonoBehaviour {
    [SerializeField] private GameObject dustObject;

    public List<GameObject> activeDustBunnies = new List<GameObject>();
    
    public float timeBetweenSpawns;
    public float dustSpeed;

    public bool shouldSpawn;

    private float _timer = 2.5f;
    
    private void Update() {
        if (shouldSpawn) {
            _timer+=Time.deltaTime;

            if (_timer >= timeBetweenSpawns) {
                SpawnDust();
                _timer = 0;
            }
        }

        foreach (var dustBunny in activeDustBunnies) {
            dustBunny.transform.position = new Vector2(dustBunny.transform.position.x + dustSpeed * Time.deltaTime,
                dustBunny.transform.position.y);
        }
    }

    private void SpawnDust() {
        GameObject newDustBunny = Instantiate(dustObject, transform.position, Quaternion.identity);
        newDustBunny.GetComponent<DustKillzone>()._dustSpawner = this;
        activeDustBunnies.Add(newDustBunny);
    }
    
    public void KillAllDust() {
        foreach (var dustBunny in activeDustBunnies) {
            Destroy(dustBunny);
        }
        activeDustBunnies.Clear();
    }

    private void OnDisable() {
        KillAllDust();
    }
}
