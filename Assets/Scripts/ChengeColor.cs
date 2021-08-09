using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeColor : MonoBehaviour
{
    public AudioSource changeColorSound;
    public Material material;
    
    private void OnTriggerEnter(Collider other)
    {
        changeColorSound.Play();
        other.GetComponent<MeshRenderer>().material = material;
    }
}
