using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockQuestThing : ScriptableObject
{
    public void UnlockVacuum() {
        FindObjectOfType<MainHousePopup>().EnableVacuum();
    }
}
