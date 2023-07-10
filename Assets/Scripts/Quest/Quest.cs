using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest/Quest")]
public class Quest : ScriptableObject {
    public List<Objective> questObjectives = new List<Objective>();
    public ObjectiveState questState = ObjectiveState.Inactive;
    public string QuestDescription;
    public UnityEvent unlock;
    private Reward _reward;

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
                switch (_reward.rewardType) {
                    case RewardType.Currency:
                        switch (_reward.currencyType) {
                            case CurrencyType.Gold:
                                GameManager.instance.CityGold.IncreaseMultiplier(_reward.rewardMultiplier);
                                break;
                            case CurrencyType.Ore:
                                GameManager.instance.CityOre.IncreaseMultiplier(_reward.rewardMultiplier);
                                break;
                            case CurrencyType.Wood:
                                GameManager.instance.CityWood.IncreaseMultiplier(_reward.rewardMultiplier);
                                break;
                        }
                        break;
                    case RewardType.Multiplier:
                        switch (_reward.currencyType) {
                            case CurrencyType.Gold:
                                GameManager.instance.CityGold.ChangeValue(_reward.rewardAmount);
                                break;
                            case CurrencyType.Ore:
                                GameManager.instance.CityOre.ChangeValue(_reward.rewardAmount);
                                break;
                            case CurrencyType.Wood:
                                GameManager.instance.CityWood.ChangeValue(_reward.rewardAmount);
                                break;
                        }
                        break;
                    case RewardType.Unlock:
                        unlock?.Invoke();
                        break;
                }
            }
        }
    }
}

public enum ObjectiveState {
    Inactive,
    Active,
    Completed
}

[System.Serializable]
public struct Reward {
    public RewardType rewardType;
    public CurrencyType currencyType;
    public float rewardMultiplier;
    public ulong rewardAmount;
}

public enum RewardType {
    Currency,
    Unlock,
    Multiplier
}