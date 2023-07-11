using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour {
    void Start() { // possible race conditions

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //gameObject.SetActive(false);
    }
}