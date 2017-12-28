using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

	public GameObject playerPrefab;
	public Text continueText;
	public Text scoreText;

	private float timeElapsed = 0f;
	private float bestTime = 0f;
	private float blinkTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;

	void Awake ()
	{
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();
	}

	// Use this for initialization
	void Start ()
	{
		var floorHeight = floor.transform.localScale.y;
		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -(Screen.height / PixelPerfectCamera.pixelsToUnits / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		Time.timeScale = 0f;

		continueText.text = "PRESS ANY BUTTON TO START";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameStarted && Time.timeScale == 0) {
			if (Input.anyKeyDown) {
				timeManager.ManipulateTime (1f, 1f);
				ResetGame ();
			}
		} 

		if (!gameStarted) {
			blinkTime++;

			if (blinkTime % 40 == 0) {
				blink = !blink;
			}

			continueText.canvasRenderer.SetAlpha (blink ? 0 : 1);

			scoreText.text = "TIME: " + FormatTime (timeElapsed) + "\nBEST: " + FormatTime (bestTime);
		} else {
			timeElapsed += Time.deltaTime;
			scoreText.text = "TIME: " + FormatTime (timeElapsed);
		}
	}

	void OnPlayerKilled ()
	{
		spawner.active = false;

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);

		gameStarted = false;

		continueText.text = "PRESS ANY BUTTON TO START";
	}

	void ResetGame ()
	{
		spawner.active = true;

		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + 100, 0));

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;

		gameStarted = true;

		continueText.canvasRenderer.SetAlpha (0);

		timeElapsed = 0f;
	}

	private string FormatTime (float value)
	{
		TimeSpan t = TimeSpan.FromSeconds (value);
		return string.Format ("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}
}
