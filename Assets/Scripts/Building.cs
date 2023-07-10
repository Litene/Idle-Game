using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public List<Quest> quests = new List<Quest>();

    private void Awake() {
        foreach (var quest in quests) {
            quest.InitializeQuest();
        }
    }
}
