using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour {
	public float speed;
	private Vector3 originalPosition;
	private GameController gc;

	void Start () {
		originalPosition = transform;
		gc = (GameController) FindObjectOfType(typeof(GameController));
	}
	// Update is called once per frame
	void Update () {
		if (!gc.SceneComplete ()) {
			transform.Rotate (Vector3.right * Time.deltaTime * speed);
		} else if (transform != originalPosition) {
			transform = originalPosition;
		}
	}
}
