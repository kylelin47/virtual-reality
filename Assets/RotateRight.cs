using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour {
	public float speed;
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (Vector3.right * Time.deltaTime * speed);
	}
}
