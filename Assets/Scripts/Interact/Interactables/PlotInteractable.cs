using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlotInteractable : Interactable {
    public GameObject buyMenuPopup;

    //TODO: clean this up please.
    public List<BuyHouseInteractable> allBuyHouseInteractables;

    private Plot owningPlot;
    public override void Use() {
        ToggleHidden();
    }
    
    public Vector3 _hiddenScale = new Vector3(0, 0, 0);
    public Vector3 _normalScale;

    void ToggleHidden() {
      
        if (buyMenuPopup.transform.localScale == _hiddenScale) {
          
            buyMenuPopup.transform.localScale = _normalScale;
            
            Debug.Log("toasf");

            foreach (var buyHouseInteractable in allBuyHouseInteractables) {
                buyHouseInteractable.owningPlot = owningPlot;
            }
        }
        else {
           
            buyMenuPopup.transform.localScale = _hiddenScale;
        }
    }
    private void Awake() {
        base.Initialize();
        _normalScale = buyMenuPopup.transform.localScale;

        allBuyHouseInteractables = FindObjectsOfType<BuyHouseInteractable>().ToList();
        
        owningPlot = GetComponent<Plot>();
    }
}
