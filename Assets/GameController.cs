using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public bool candle;
	public bool book;
	public bool bell;
	// Use this for initialization
	void Start () {
		candle = false;
		book = false;
		bell = false;
	}

	void Update() {
		if (SceneComplete()) {
			AudioSource bgm = GameObject.FindWithTag ("BGM").GetComponent<AudioSource>();
			bgm.Stop ();
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
}
