using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {
    public List<GameObject> LeftPopups, RightPopups;

    public void CloseAllLeftPopups() {
        foreach (GameObject popup in LeftPopups) {
            popup.SetActive(false);
        }
    }

    public void CloseAllRightPopups() {
        foreach (GameObject popup in RightPopups) {
            popup.SetActive(false);
        }
    }
}
