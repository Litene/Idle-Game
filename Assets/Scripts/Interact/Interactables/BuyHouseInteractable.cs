using UnityEngine;

public class BuyHouseInteractable : Interactable {
    public Plot owningPlot;
    public GameObject buildingToBuild;

    public void SetOwningPlot(Plot newOwner) {
        owningPlot = newOwner;
    }

    //TODO: remove plot clickable and have the building be clickable instead
        public override void Use() {
            if (owningPlot == null) {
                return;
            }
            
            owningPlot.BuildBuilding(buildingToBuild);
        }
    
        private void Awake() {
            base.Initialize();
        }
}
