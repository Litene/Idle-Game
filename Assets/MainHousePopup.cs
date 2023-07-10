using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHousePopup : MonoBehaviour {
    [SerializeField] private GameObject vacuum;
    [SerializeField] private DustSpawner dustSpawner;
    
    public void EnableVacuum() {
        Debug.Log("Enabling Vacuum");
        vacuum.SetActive(true);
        dustSpawner.killValue = -5f;
        dustSpawner.hasVacuum = true;
    }
}
