using UnityEngine;
using System.Collections;

public class PointPickup : MonoBehaviour {

	public int pointsToAdd;

	public AudioSource pointSoundEffect;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);

		pointSoundEffect.Play ();

		Destroy (gameObject);
	}
}
