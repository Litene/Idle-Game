using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutterPopup : MonoBehaviour {
    public TreeSpawner treeSpawner;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject npcObject;

    private bool playerTurnToChop = true;

    private void Start() {
        UpdateInteractables();
    }

    public void ChopTrunk() {
        treeSpawner.RemoveTrunkSection(playerTurnToChop);
        playerTurnToChop = !playerTurnToChop;
        UpdateInteractables();
    }

    public void UpdateInteractables() {
        if (playerTurnToChop) {
            playerObject.GetComponent<SpriteRenderer>().color = Color.white;
            npcObject.GetComponent<SpriteRenderer>().color = new Color(.15f, .15f, .15f, 1);

            playerObject.GetComponent<EventClick>().enabled = true;
            npcObject.GetComponent<EventClick>().enabled = false;
        }
        else {
            playerObject.GetComponent<SpriteRenderer>().color = new Color(.15f, .15f, .15f, 1);
            npcObject.GetComponent<SpriteRenderer>().color = Color.white;
            
            playerObject.GetComponent<EventClick>().enabled = false;
            npcObject.GetComponent<EventClick>().enabled = true;
        }
    }
}
