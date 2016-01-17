using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]
[RequireComponent(typeof (AudioSource))]
public class PlayerMovement : MonoBehaviour {
	public float speed;
	[SerializeField] private float m_StepInterval;
	[SerializeField] private AudioClip[] m_FootstepSounds;
	private CharacterController m_CharacterController;
	private float m_StepCycle;
	private float m_NextStep;
	private AudioSource m_AudioSource;
	private void Start()
	{
		m_CharacterController = GetComponent<CharacterController>();
		m_StepCycle = 0f;
		m_NextStep = m_StepCycle/2f;
		m_AudioSource = GetComponent<AudioSource>();
	}
	void Update() // called once per frame
	{
		m_CharacterController.SimpleMove(changeToGroundMovement());
	}
	void FixedUpdate()
	{
		ProgressStepCycle(speed);
	}
	Vector3 changeToGroundMovement()
	{
		Vector3 movement = Camera.main.transform.right * Input.GetAxisRaw ("Horizontal") +
			Camera.main.transform.forward * Input.GetAxisRaw ("Vertical");
		movement.y = 0;
		movement.Normalize ();
		return movement * speed;
	}
	private void ProgressStepCycle(float speed)
	{
		if (m_CharacterController.velocity.sqrMagnitude > 0 &&
			(Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0))
		{
			m_StepCycle += (m_CharacterController.velocity.magnitude + speed)*
				Time.fixedDeltaTime;
		}

		if (!(m_StepCycle > m_NextStep))
		{
			return;
		}

		m_NextStep = m_StepCycle + m_StepInterval;

		PlayFootStepAudio();
	}
	private void PlayFootStepAudio()
	{
		if (!m_CharacterController.isGrounded)
		{
			return;
		}
		// pick & play a random footstep sound from the array,
		// excluding sound at index 0
		int n = Random.Range(1, m_FootstepSounds.Length);
		m_AudioSource.clip = m_FootstepSounds[n];
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
		// move picked sound to index 0 so it's not picked next time
		m_FootstepSounds[n] = m_FootstepSounds[0];
		m_FootstepSounds[0] = m_AudioSource.clip;
	}
}
