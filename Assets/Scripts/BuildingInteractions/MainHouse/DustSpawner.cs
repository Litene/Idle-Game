using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DustSpawner : MonoBehaviour {
	[SerializeField] private GameObject dustObject;

	public List<GameObject> activeDustBunnies = new List<GameObject>();

	public float timeBetweenSpawns;
	public float dustSpeed = 1.25f;
	private bool _shouldSpawnInvisible = true;

	public bool ShouldSpawnInvisible {
		get => _shouldSpawnInvisible;
		set {
			if (value) {
				foreach (var activeBunny in activeDustBunnies) {
					if (!activeBunny.IsDestroyed()) {
						activeBunny.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 0, 0, 0);
					}
				}
			}
			else {
				foreach (var activeBunny in activeDustBunnies) {
					if (!activeBunny.IsDestroyed()) {
						activeBunny.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
					}
				}
			}

			_shouldSpawnInvisible = value;
		}
	}

	public bool shouldSpawn;

	private float _timer = 2.5f;

	public bool hasVacuum = false;
	public float killValue = -2.4f;

	private void Update() {
		if (shouldSpawn) {
			_timer += Time.deltaTime;

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
		if (ShouldSpawnInvisible) {
			GameObject newDustBunny = Instantiate(dustObject, transform.position, Quaternion.identity);
			newDustBunny.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 0, 0, 0);
			newDustBunny.GetComponent<DustKillzone>()._dustSpawner = this;
			activeDustBunnies.Add(newDustBunny);
		}
		else {
			GameObject newDustBunny = Instantiate(dustObject, transform.position, Quaternion.identity);
			newDustBunny.GetComponent<DustKillzone>()._dustSpawner = this;
			activeDustBunnies.Add(newDustBunny);
		}
	}

	// public void KillAllDust() {
	//     foreach (var dustBunny in activeDustBunnies) {
	//         Destroy(dustBunny);
	//     }
	//     activeDustBunnies.Clear();
	// }
	//
	// private void OnDisable() {
	//     KillAllDust();
	// }
}