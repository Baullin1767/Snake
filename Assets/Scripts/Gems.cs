using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
	public AudioSource gemsSound;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			gemsSound.Play();
			Destroy(gameObject);
		}
	}
}
