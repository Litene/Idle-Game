using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModel {
    public List<IModelListener> Listeners { get; set; }
    public IModel RegisterListener(IModelListener listener);
}

public interface IModelListener {
    public IModel Model { get; set; }
    public double UpdateGold(double currentGold);
    public double UpdateOre(double currentOre);
    public double UpdateWood(double currentWood);
    
}
