using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SnakeMovment : MonoBehaviour {

	public float speed = 3f;
	public float z_offset = 1.5f;
		
	public List<GameObject> tailObjects = new List<GameObject>();
	public GameObject TailPrefab;

	Rigidbody rb;
	public TouchPad touchPad;
	public GameObject _touchPad;

	public Text scoreText;
	int score;
	public Text gemsText;
	int gems;

	bool fever = false;
	bool move = true;

	AudioSource feverSound;

	void Start () 
	{
		feverSound = gameObject.GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
		tailObjects.Add(gameObject);
	}
    private void Update()
    {
		scoreText.text = score.ToString();
		gemsText.text = gems.ToString();
    }

    private void FixedUpdate()
	{
		if (gems == 3)
		{
			fever = true;
			rb.transform.position = new Vector3(0, 0, transform.position.z);
			float speedFever = speed * 3;
			transform.Translate(Vector3.forward * speedFever * Time.deltaTime);
			_touchPad.SetActive(false);
			feverSound.Play();
			Invoke("ResetGems", 5.0f);
        }
        else if (move == true)
		{
			fever = false;
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			Vector2 direction = touchPad.GetDirection();
			rb.velocity = new Vector2(direction.x, 0) * speed;
        }
	}

    public void ResetGems()
    {
		gems = 0;
		_touchPad.SetActive(true);
    }

    public void AddTail()
	{
		score++;
		Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
		newTailPos.z -= z_offset;
		tailObjects.Add(Instantiate(TailPrefab,newTailPos,Quaternion.identity));
	}
	public void RemoveTail()
	{
        if (tailObjects.Count > 1)
        {
			score--;
            GameObject Tail = tailObjects[tailObjects.Count - 1];
            tailObjects.Remove(Tail);
			Destroy(Tail);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (fever == false)
        {
            if (other.CompareTag("NotFood"))
            {
                RemoveTail();

            }
            else if (other.CompareTag("Cylinder"))
            {
                FindObjectOfType<GameManager>().Damage();
            }
            else if (other.CompareTag("Gems"))
            {
                gems++;
            }
        }
        else
        {
			AddTail();
        }
    }
		
	public void GameOver() 
	{
		move = false;
	}
}
