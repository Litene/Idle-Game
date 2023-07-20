using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour {

    public bool notScaleMode;
    
    void Start() { // possible race conditions
        if (!notScaleMode) {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            //gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}