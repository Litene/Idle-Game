using System;
using TMPro;
using UnityEngine;

[Serializable]
public class ToolTip {
    public GameObject toolTipPrefab;
    public TextMeshProUGUI toolTipTextRef;
    public string toolTipText;

    public void ToggleTooltip(bool disable) {
        if (disable) {
            toolTipPrefab.SetActive(false);
            return;
        }

        toolTipPrefab.SetActive(true);

        if (!toolTipTextRef) {
            toolTipTextRef = toolTipPrefab.GetComponentInChildren<TextMeshProUGUI>();
        }

        toolTipTextRef.text = toolTipText;
    }

    public void UpdateTooltipText(string newTooltipText) {
        toolTipText = newTooltipText;
        toolTipTextRef.text = toolTipText;
    }
}