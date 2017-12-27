using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public RecycleGameObject prefab;

	private List<RecycleGameObject> poolInstances = new List<RecycleGameObject> ();

	private RecycleGameObject CreateInstance (Vector3 pos)
	{
		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;

		poolInstances.Add (clone);

		return clone;
	}

	public RecycleGameObject NextObject (Vector3 pos)
	{
		RecycleGameObject instance = null;

		instance = CreateInstance (pos);
		instance.Restart ();

		return instance;
	}
}
