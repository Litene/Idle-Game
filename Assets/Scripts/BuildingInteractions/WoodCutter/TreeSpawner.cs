using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {
    [SerializeField] private GameObject trunkSection;

    public float trunkFallSpeed;

    private int orignialLayer;

    public List<GameObject> activeTrunkSections = new();
    public float[] targetPositions = new float[] {
        -2.1f,
        -1.6f,
        -1.1f,
        -0.6f,
        -0.1f
    };

    private Queue<IEnumerator> movingQueue = new();

    private Queue<IEnumerator> MovingQueue {
        get => movingQueue;
        set {
            if (movingQueue.Count == 0) {
                movingQueue = value;
                StartCoroutine(ExecuteQueue());
            }
            else {
                movingQueue = value;
            }
        }
    }

    private void Awake() {
        orignialLayer = trunkSection.GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Start() {
        for (int i = 0; i < 5; i++) {
            SpawnNextTrunkSection();
        }

        StartCoroutine(ExecuteQueue());
    }

    public void SpawnNextTrunkSection() {
        if (FindObjectsOfType<TrunkInfo>().Length > 5) {
            return;
        }
        StartCoroutine(MoveTrunk());
    }

    public void RemoveTrunkSection(bool playerChopped) {
        if (!(activeTrunkSections.Count > 0)) {
            return;
        }

        if (!activeTrunkSections.Any(trunk => trunk.GetComponent<TrunkInfo>().isMoving)) {
            StartCoroutine(RemoveLog(playerChopped));
        }
    }

    private IEnumerator MoveTrunk(GameObject targetTrunk = null) {
        if (!targetTrunk) {
            targetTrunk = Instantiate(trunkSection, transform.position, quaternion.identity, transform);
            activeTrunkSections.Add(targetTrunk);
            UpdateTrunkLayers();
        }

        targetTrunk.GetComponent<TrunkInfo>().isMoving = true;
        
        int targetIndex = activeTrunkSections.IndexOf(targetTrunk);

        while (Mathf.Abs(targetTrunk.transform.localPosition.y - targetPositions[targetIndex]) > 0.01f) {
            float nextStep = targetTrunk.transform.localPosition.y - (trunkFallSpeed * Time.deltaTime);
            if (nextStep < targetPositions[targetIndex]) {
                nextStep = targetPositions[targetIndex];
            }

            targetTrunk.transform.localPosition = new Vector3(targetTrunk.transform.localPosition.x, nextStep, targetTrunk.transform.localPosition.z);
            
            yield return null;
        }
        
        targetTrunk.GetComponent<TrunkInfo>().isMoving = false;
    }

    private IEnumerator RemoveLog(bool playerChopped) {
        float target = playerChopped ? .75f : -.75f;

        GameObject logToRemove = activeTrunkSections[0];

        while (Mathf.Abs(logToRemove.transform.localPosition.x - target) > 0.01f) {
            float nextStep = logToRemove.transform.localPosition.x + (Mathf.Sign(target) * (trunkFallSpeed*2) * Time.deltaTime);
            if (!playerChopped) {
                if (nextStep < target) {
                    nextStep = target;
                }
            }
            else {
                if (nextStep > target) {
                    nextStep = target;
                }
            }
            
            logToRemove.transform.localPosition = new Vector3(nextStep, logToRemove.transform.localPosition.y, logToRemove.transform.localPosition.z);
            
            yield return null;
        }
        
        activeTrunkSections.Remove(activeTrunkSections[0]);

        foreach (var trunk in activeTrunkSections) {
            StartCoroutine(MoveTrunk(trunk));
        }
        
        SpawnNextTrunkSection();

        Destroy(logToRemove, .1f);
    }

    private IEnumerator ExecuteQueue() {
        while (movingQueue.Count > 0) {
            yield return movingQueue.Dequeue();
        }
    }

    private void UpdateTrunkLayers() {
        foreach (var trunk in activeTrunkSections) {
            trunk.GetComponent<SpriteRenderer>().sortingOrder = orignialLayer + activeTrunkSections.IndexOf(trunk);
        }
    }
}