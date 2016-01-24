using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour {
	public float speed;
	private Quaternion originalRotation;
	private GameController gc;
	private CardboardAudioSource src;

	void Start () {
		originalRotation = transform.rotation;
		gc = (GameController) FindObjectOfType(typeof(GameController));
	}
	// Update is called once per frame
	void Update () {
		if (!gc.SceneComplete ()) {
			transform.Rotate (Vector3.right * Time.deltaTime * speed);
		} else {
			if (transform.rotation != originalRotation) {
				transform.rotation = originalRotation;
			}
			if (src == null) {
				src = GetComponent<CardboardAudioSource> ();
				src.Stop ();
			}
		}
	}
}
