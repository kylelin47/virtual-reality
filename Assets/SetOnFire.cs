using UnityEngine;
using System.Collections;

public class SetOnFire : MonoBehaviour {
	private GameObject flame;
	private bool gazedAt;
	// Use this for initialization
	void Start () {
		flame = GameObject.FindWithTag ("Flame");
		flame.SetActive (false);

		gazedAt = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && gazedAt) {
			flame.SetActive (true);
		}
	}
	public void SetGazedAt(bool gazedAt) {
		this.gazedAt = gazedAt;
	}
}
