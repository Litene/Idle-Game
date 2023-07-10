using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField] private TMP_Text dialogueLabel;

    [SerializeField] private Image playerPortrait;
    [SerializeField] private Image npcPortrait;
    
    private Typewriter _typewriter;

    private int _dialogueSlides;
    private int _currentSlide;

    public DialogueInfo dialogueInfo;

    private void Awake() {
        _typewriter = GetComponent<Typewriter>();

        _dialogueSlides = dialogueInfo.dialogueLines.Count;
        
        playerPortrait.sprite = dialogueInfo.playerPortrait;
        npcPortrait.sprite = dialogueInfo.npcPortrait;

        dialogueLabel.text = String.Empty;
    }

    private void Start() {
        PlayNextSlide();
    }

    private void Update() {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) {
            if (_typewriter.isTyping) {
                _typewriter.currentTypingSpeed = Typewriter.TypingSpeed.Fast;
            }
            else {
                if (_currentSlide >= _dialogueSlides) {
                    Destroy(gameObject);
                }
                else {
                    PlayNextSlide();
                }
            }
        }
        else {
            _typewriter.currentTypingSpeed = Typewriter.TypingSpeed.Normal;
        }
    }

    private void PlayNextSlide() {
        _typewriter.isTyping = true;
        _typewriter.TypewriteText(dialogueInfo.dialogueLines[_currentSlide], dialogueLabel);

        switch (dialogueInfo.dialogueSpeakerOrder[_currentSlide]) {
            case DialogueInfo.DialogueSpeaker.Player:
                playerPortrait.color = Color.white;
                npcPortrait.color = new Color(.15f, .15f, .15f, 1);
                break;
            case DialogueInfo.DialogueSpeaker.NPC:
                playerPortrait.color = npcPortrait.color = new Color(.15f, .15f, .15f, 1);
                npcPortrait.color = Color.white;
                break;
        }

        _currentSlide++;
    }
}
