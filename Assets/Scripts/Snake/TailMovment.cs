using UnityEngine;
using System.Collections;

public class TailMovment : MonoBehaviour {

	public float Speed;
	public Vector3 tailTarget;
	public int indx;
	public GameObject tailTargetObj;
	public SnakeMovment mainSnake;

	void Start()
	{
		mainSnake = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeMovment>();
		Speed = mainSnake.speed+2.5f;
		tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count-2];
		indx = mainSnake.tailObjects.IndexOf(gameObject);
	}
	void Update() 
	{
		tailTarget = tailTargetObj.transform.position;
		transform.LookAt(tailTarget);
		transform.position = Vector3.Lerp(transform.position,tailTarget,Time.deltaTime*Speed);
	}

}
