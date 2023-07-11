using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {
    public List<GameObject> LeftPopups, RightPopups;
    public List<Vector3> LeftPopupsNormalScale, RightPopupsNormalScale;

    private void Start() {
        foreach (var leftPopup in LeftPopups) {
            LeftPopupsNormalScale.Add(leftPopup.transform.localScale);
        }

        foreach (var rightPopup in RightPopups) {
            RightPopupsNormalScale.Add(rightPopup.transform.localScale);
        }
    }

    public void CloseAllLeftPopups() {
        // foreach (GameObject popup in LeftPopups) {
        //     popup.SetActive(false);
        // }

        for (int i = 0; i < LeftPopups.Count; i++) {
            LeftPopups[i].transform.localScale = _hiddenScale;
        }
    }

    public void CloseAllRightPopups() {
        for (int i = 0; i < LeftPopups.Count; i++) {
            RightPopups[i].transform.localScale = _hiddenScale;
        }
        // foreach (GameObject popup in RightPopups) {
        //     popup.SetActive(false);
        // }
    }
    
    private Vector3 _hiddenScale = new Vector3(0, 0, 0);
    private Vector3 _normalScale;

    void ToggleHidden(GameObject gO, bool hide) {
        if (hide) {
            gO.transform.localScale = _hiddenScale;
        }
        else {
            gO.transform.localScale = _normalScale;
        }
    }
}
