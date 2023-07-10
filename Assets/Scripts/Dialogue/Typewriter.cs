using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Typewriter : MonoBehaviour {
    public float typeSpeed;
    public float fastTypeSpeed;

    public bool isTyping;

    public TypingSpeed currentTypingSpeed = TypingSpeed.Normal;

    [SerializeField] private AudioClip[] dialogueTypingSounds;
    private AudioSource _audioSource;

    [Range(1,5)]
    [SerializeField] private int speakFrequency;
    
    [SerializeField] private bool stopAudioBeforeNextOne;
    [SerializeField] private bool playPredictedSounds;

    [Range(-3,3)]
    [SerializeField] private float minPitch = .5f;
    [Range(-3,3)]
    [SerializeField] private float maxPitch = 3f;

    private void Awake() {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public void TypewriteText(string textLine, TMP_Text textLabel) {
        StartCoroutine(TypeText(textLine, textLabel));
    }

    private void PlayDialogueSound(int currentDisplayedCharacterCount, char currentCharacter) {
        if (currentDisplayedCharacterCount % speakFrequency == 0) {
            if (stopAudioBeforeNextOne) {
                _audioSource.Stop();
            }

            AudioClip soundToPlay = null;
            if (playPredictedSounds) {
                int hashCode = currentCharacter.GetHashCode();

                int predictableIndex = hashCode % dialogueTypingSounds.Length;
                soundToPlay = dialogueTypingSounds[predictableIndex];

                int minPitchInt = (int)(minPitch * 100);
                int maxPitchInt = (int)(maxPitch * 100);
                int pitchRangeInt = maxPitchInt - minPitchInt;

                if (pitchRangeInt != 0) {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                    float predictablePitch = predictablePitchInt / 100f;
                    _audioSource.pitch = predictablePitch;
                }
                else {
                    _audioSource.pitch = minPitch;
                }
            }
            else {
                int Index = Random.Range(0, dialogueTypingSounds.Length);
                soundToPlay = dialogueTypingSounds[Index];
            
                _audioSource.pitch = Random.Range(minPitch, maxPitch);
            }
            
            
            _audioSource.PlayOneShot(soundToPlay);
        }
    }
    
    private IEnumerator TypeText(string textToType, TMP_Text textLabel) {
        float t = 0;
        int charIndex = 0;
        int lastFrameCharIndex = -1;

        while (charIndex < textToType.Length) {
            switch (currentTypingSpeed) {
                case TypingSpeed.Normal:
                    t += Time.deltaTime * typeSpeed;
                    break;
                case TypingSpeed.Fast:
                    t += Time.deltaTime * fastTypeSpeed;
                    break;
            }
            
            if (charIndex > lastFrameCharIndex) {
                PlayDialogueSound(charIndex, textToType[charIndex]);
            }
            
            lastFrameCharIndex = charIndex;
            
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
        isTyping = false;
    }

    public enum TypingSpeed {
        Normal,
        Fast
    }
}
