﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;
	private InputState inputState;

	void Awake () {
		animator = GetComponent<Animator> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		var running = true;

		// play is dragged off of the screen
		if (inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold) {
			running = false;
		}

		animator.SetBool ("Running", running);
	}
}
