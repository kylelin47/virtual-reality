using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public bool candle;
	public bool book;
	public bool bell;
	private GameObject steam;
	private bool ended;
	// Use this for initialization
	void Start () {
		candle = false;
		book = false;
		bell = false;
		ended = false;
		steam = GameObject.FindWithTag ("Steam");
		steam.SetActive (false);
	}

	void Update() {
		if (SceneComplete() && !ended) {
			AudioSource bgm = GameObject.FindWithTag ("BGM").GetComponent<AudioSource>();
			bgm.Stop ();
			StartCoroutine ("EscapeSpirit");
			ended = true;
		}
	}
	public bool ActiveBell() {
		return !bell;
	}

	public bool ActiveBook() {
		return bell && !book;
	}
	public bool ActiveCandle() {
		return bell && book && !candle;
	}

	public bool GetInteractionKey() {
		return Input.GetKeyDown (KeyCode.Space);
	}

	public bool SceneComplete() {
		return bell && book && candle;
	}

	private IEnumerator EscapeSpirit() {
		yield return new WaitForSeconds (5.0f);
		steam.SetActive (true);
	}
}
