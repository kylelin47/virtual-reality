using UnityEngine;
using System.Collections;

public class ReadBook : MonoBehaviour {
	private CardboardAudioSource src;
	private GameController gc;
	private LightController lc;

	public void BeginReading () {
		src = GetComponent<CardboardAudioSource> ();
		gc = (GameController) FindObjectOfType(typeof(GameController));
		lc = (LightController) FindObjectOfType(typeof(LightController));
		src.Play ();
		lc.holy = true;
		StartCoroutine ("FinishReading");
	}

	private IEnumerator FinishReading() {
		yield return new WaitForSeconds (30.0f);
		gc.book = true;
		Destroy (gameObject);
	}
}
