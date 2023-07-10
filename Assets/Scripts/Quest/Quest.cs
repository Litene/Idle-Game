using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest/Quest")]
public class Quest : ScriptableObject {
    public List<Objective> questObjectives = new List<Objective>();

    public ObjectiveState questState = ObjectiveState.Inactive;

    public ObjectiveState QuestState {
        get => questState;
        set {
            if (questState == ObjectiveState.Inactive && value == ObjectiveState.Active) {
                foreach (Objective objective in questObjectives) {
                    objective.ActivateObjective();
                }
            }
            questState = value;
        }
    }

    public void InitializeQuest() {
        QuestState = ObjectiveState.Active;
        
        foreach (Objective objective in questObjectives) {
            objective.InitializeObjective(this);
        }
    }

    public void TryComplete() {
        Debug.Log("Calling TryComplete");
        if (questObjectives.TrueForAll(state => state.objectiveState == ObjectiveState.Completed)) {
            Debug.Log("All Objectives Completed");
            if (QuestState == ObjectiveState.Active) {
                Debug.Log("Quest State set to Complete");
                QuestState = ObjectiveState.Completed;
            }
        }
    }
}

public enum ObjectiveState {
    Inactive,
    Active,
    Completed
}