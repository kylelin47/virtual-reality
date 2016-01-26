using UnityEngine;
using System.Collections;

public class RotateRight : MonoBehaviour {
	public float speed;
	private Quaternion originalRotation;
	private GameController gc;
	private CardboardAudioSource src;
	private bool reset = false;
	private bool turning = true;
	private bool flag = true;
	void Start () {
		originalRotation = transform.rotation;
		gc = (GameController) FindObjectOfType(typeof(GameController));
		src = GetComponent<CardboardAudioSource> ();
	}
	// Update is called once per frame
	void Update () {
		if (!gc.SceneComplete ()) {
			if (flag) {
				StartCoroutine ("StopTurning");
				src.Play ();
				flag = false;
			}
			if (turning) {
				transform.Rotate (Vector3.right * Time.deltaTime * speed);
			}
		} else {
			if (!reset) {
				transform.rotation = originalRotation;
				StopCoroutine ("StopTurning");
				reset = true;
			}
			src.Stop ();
		}
	}

	private IEnumerator StopTurning() {
		yield return new WaitForSeconds (3.0f);
		turning = false;
		yield return new WaitForSeconds (1.5f);
		turning = true;
		flag = true;
	}
}
