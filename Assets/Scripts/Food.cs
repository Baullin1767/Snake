using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour 
{
	public AudioSource foodSound;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			foodSound.Play();
			Destroy(gameObject);
		}
	}

}
