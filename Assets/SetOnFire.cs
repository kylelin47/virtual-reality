using UnityEngine;
using System.Collections;

public class SetOnFire : MonoBehaviour {
	private GameObject flame;
	private GameObject player;
	private GameController gc;
	private bool gazedAt;
	public float interactionDistance;
	// Use this for initialization
	void Start () {
		flame = GameObject.FindWithTag ("Flame");
		player = GameObject.FindWithTag ("Player");
		gc = (GameController) FindObjectOfType(typeof(GameController));
		flame.SetActive (false);

		gazedAt = false;
	}

	// Update is called once per frame
	void Update () {
		if (gc.ActiveCandle() && gc.GetInteractionKey() && gazedAt &&
			Vector3.Distance(transform.position, player.transform.position) < interactionDistance) {
			gc.candle = true;
			flame.SetActive (true);
		}
	}
	public void SetGazedAt(bool gazedAt) {
		this.gazedAt = gazedAt;
	}
}
