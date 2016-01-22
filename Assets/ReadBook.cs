using UnityEngine;
using System.Collections;

public class ReadBook : MonoBehaviour {
	private CardboardAudioSource src;
	// Use this for initialization
	void Start () {
		src = GetComponent<CardboardAudioSource> ();
	}
	
	public void BeginReading () {
		src.PlayDelayed (0.5f);
	}
}
