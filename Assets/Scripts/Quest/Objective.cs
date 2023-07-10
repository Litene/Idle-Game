using UnityEngine;
using UnityEngine.Serialization;

public class Objective : ScriptableObject {
    public ObjectiveState objectiveState = ObjectiveState.Inactive;

    public Quest OwningQuest;
    
    public virtual void InitializeObjective(Quest owner) {
        
    }

    public void ActivateObjective() {
        if (objectiveState == ObjectiveState.Inactive) {
            objectiveState = ObjectiveState.Active;
        }
    }

    public virtual void ProgressQuest() {
        
    }
}