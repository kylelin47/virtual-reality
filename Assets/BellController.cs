using UnityEngine;
using System.Collections;

public class BellController : MonoBehaviour {
	private GameObject player;
	private GameController gc;
	private CardboardAudioSource src;
	private bool gazedAt;
	public float interactionDistance;
	// Use this for initialization
	void Start () {
		src = GetComponent<CardboardAudioSource> ();
		player = GameObject.FindWithTag ("Player");
		gc = (GameController) FindObjectOfType(typeof(GameController));
		gazedAt = false;
	}

	// Update is called once per frame
	void Update () {
		if (gc.ActiveBell() && gc.GetInteractionKey() && gazedAt &&
			Vector3.Distance(transform.position, player.transform.position) < interactionDistance) {
			gc.bell = true;
			src.Play ();
		}
		if (gc.SceneComplete ()) {
			src.Stop ();
		}
	}
	public void SetGazedAt(bool gazedAt) {
		this.gazedAt = gazedAt;
	}
}
