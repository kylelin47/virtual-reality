using UnityEngine;
using System.Collections;

public class SpineController : MonoBehaviour {
	public float speed;
	private GameController gc;

	void Start () {
		gc = (GameController) FindObjectOfType(typeof(GameController));
	}
	// Update is called once per frame
	void Update () {
		if (gc.SceneComplete () && transform.rotation.z < -0.2f) {
			transform.Rotate (Vector3.forward * Time.deltaTime * speed);
		}
	}
}
