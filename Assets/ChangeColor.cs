using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	void LateUpdate()
	{
		Cardboard.SDK.UpdateState();
	}

	public void click()
	{
		GetComponent<Renderer> ().material.color = Color.cyan;
	}
}
