using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 direction;
	public float roamRadius;
	public float speed;
	public float directionChangeFrequency;
	private GameController gc;

	void Start() {
		gc = (GameController) FindObjectOfType(typeof(GameController));
		startPosition = transform.position;
		direction = Vector3.right;
		InvokeRepeating ("ChangeDirection", 0.0f, directionChangeFrequency);
	}

	void Update() {
		if (gc.SceneComplete ()) {
			Destroy (gameObject);
		}
		if ((Vector3.Distance (transform.position, startPosition) < roamRadius)) {
			transform.position += direction * speed * Time.deltaTime;
		} else {
			Vector3.MoveTowards (transform.position, startPosition, speed * Time.deltaTime);
		}
	}
	void ChangeDirection() {
		direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-0.1f, 0.1f), Random.Range(-1.0f, 1.0f))).normalized;
	}
}
