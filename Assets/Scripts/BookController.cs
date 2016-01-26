using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour {
	private GameObject player;
	private GameObject openBook;
	private GameController gc;
	private bool gazedAt;
	public float interactionDistance;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		openBook = GameObject.FindWithTag ("OpenBook");
		openBook.SetActive (false);
		gc = (GameController) FindObjectOfType(typeof(GameController));
		gazedAt = false;
	}

	// Update is called once per frame
	void Update () {
		if (gc.ActiveBook() && gc.GetInteractionKey() && gazedAt &&
			Vector3.Distance(transform.position, player.transform.position) < interactionDistance) {
			openBook.SetActive (true);
			ReadBook read = (ReadBook) FindObjectOfType(typeof(ReadBook));
			read.BeginReading ();
			Destroy (gameObject);
		}
	}
	public void SetGazedAt(bool gazedAt) {
		this.gazedAt = gazedAt;
	}
}
