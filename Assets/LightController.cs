using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	private Light myLight;
	public bool holy;
	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (holy) {
			myLight.spotAngle += 0.05f;
			myLight.intensity += 0.001f;
		}
	}
}
