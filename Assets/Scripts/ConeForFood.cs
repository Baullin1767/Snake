using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeForFood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            FindObjectOfType<SnakeMovment>().AddTail();

        }
    }
}
