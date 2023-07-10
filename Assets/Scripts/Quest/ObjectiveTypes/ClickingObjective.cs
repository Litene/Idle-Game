using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Objectives/Clicking Objective")]
public class ClickingObjective : Objective, IEventListener {
    [SerializeField] private GameObject objectToClick;
    [SerializeField] private int clickCounter;
    [SerializeField] private int clicksToWin;

    public override void InitializeObjective(Quest owner) {
        OwningQuest = owner;
        
        foreach (var eventHandler in FindObjectsOfType<MonoBehaviour>().OfType<IEventHandler>()) {
            eventHandler.RegisterListener(this);
        }
    }

    public override void ProgressQuest() {
        if (objectiveState != ObjectiveState.Active) {
            return;
        }
        
        if (clickCounter >= clicksToWin) {
            Debug.Log("Setting objective to Completed");
            objectiveState = ObjectiveState.Completed;
            OwningQuest.TryComplete();
        }
    }

    public void OnClicked(GameObject clickedObject) {
        if (clickedObject.CompareTag(objectToClick.tag)) {
            clickCounter++;
            ProgressQuest();
        }
    }
    
    public IEventHandler EventHandler { get; set; }
}
