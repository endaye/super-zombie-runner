using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleGameObject : MonoBehaviour
{

	public void Restart ()
	{
		gameObject.SetActive (true);
	}

	public void Shutdown ()
	{
		gameObject.SetActive (false);
	}

}