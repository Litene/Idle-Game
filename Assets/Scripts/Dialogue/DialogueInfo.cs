using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/Dialogue Info")]
public class DialogueInfo : ScriptableObject { 
    
    public List<string> dialogueLines;
    public List<DialogueSpeaker> dialogueSpeakerOrder;

    public Sprite playerPortrait;
    public Sprite npcPortrait;

    public enum DialogueSpeaker {
        Player,
        NPC
    }
}
