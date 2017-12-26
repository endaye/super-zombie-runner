using System.Collections;
using UnityEngine;

public class GameObjectUtil {
	
	public static GameObject Instantiate(GameObject prefab, Vector3 pos) {
		GameObject instance = null;

		instance = GameObject.Instantiate (prefab);
		instance.transform.position = pos;

		return null;
	}

	public static void Destroy(GameObject gameObject) {
		GameObject.Destroy (gameObject);
	}
}
