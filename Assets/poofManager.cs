using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofManager : MonoBehaviour {
    private SpriteRenderer _spriteRenderer;
    public float lerpSpeed = 5;
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, new Color(1, 1, 1, 0), Time.deltaTime * lerpSpeed);
    }
}
