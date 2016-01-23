using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	private Light light;
	public bool holy;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (holy) {
			light.spotAngle += 0.05f;
			light.intensity += 0.001f;
		}
	}
}
