using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventHandler {
    public List<IEventListener> Listeners { get; set; }
    public IEventHandler RegisterListener(IEventListener listener);
}

public interface IEventListener {
    public IEventHandler EventHandler { get; set; }

    public void OnClicked(GameObject clickedObject);
}
