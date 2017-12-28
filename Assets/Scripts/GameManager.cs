using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;

	private GameObject player;
	private GameObject floor;
	private Spawner spawner;

	void Awake() {
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
	}

	// Use this for initialization
	void Start () {
		var floorHeight = floor.transform.localScale.y;
		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -(Screen.height / PixelPerfectCamera.pixelsToUnits / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		ResetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetGame() {
		spawner.active = true;
		player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2, 0));
	}
}
