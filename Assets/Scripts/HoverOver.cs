using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOver : MonoBehaviour {

	private Collider2D _collider;
	private void Awake() {
		
		_collider = GetComponent<Collider2D>();
	}

	private void Update() {
		Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
		if (_collider && colliderHit == _collider) {
			Debug.Log(_collider.gameObject);
		}
	}
}