using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFood : MonoBehaviour
{
	public AudioSource notFoodSound;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			notFoodSound.Play();
			Destroy(gameObject);
		}
	}
}
