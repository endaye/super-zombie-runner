using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public void ManipulateTime(float newTime, float duration) {
		if (Time.timeScale == 0) {
			Time.timeScale = 0.1f;
		}

		StartCoroutine (FadeTo (newTime, duration));
	}


	IEnumerator FadeTo(float value, float time) {
		for (float t = 0f; t < 1f; t += Time.deltaTime / time) {
			Time.timeScale = Mathf.Lerp (Time.timeScale, value, t);

			if (Mathf.Abs(value - Time.timeScale) < .01f) {
				Time.timeScale = value;
				break;
			}

			yield return null;
		}
	}
}
