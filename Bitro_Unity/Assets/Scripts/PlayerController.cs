using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	
	private Rigidbody rb;
	private int count;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ( "Pick Up2"))
		{
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ( "Boom"))
		{
			other.gameObject.SetActive (false);
			count = count - 3;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ( "Pick Up3"))
		{
			other.gameObject.SetActive (false);
			count = count + 45 ;
			SetCountText ();
		}
	}
	
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 100)
		{
			winText.text = "Felicitari, ai trecut la nivelul urmator!~ ";
			int i = Application.loadedLevel;
			Application.LoadLevel(i + 1);
		}
	}

}