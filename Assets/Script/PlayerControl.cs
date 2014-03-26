using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	protected int count;
	public float turnspeed;
	public GameObject playerControlControler;
	public GameObject level2Plane;
	public GameObject level3Plane;
	public GUIText countText;
	public GUIText timeText;
	public GUIText lossText;
	private int totalTime;
	private int timeLeft;
	private float timePass;
	private int level;
	// Use this for initialization
	void Start (){
		count = 0;
		totalTime = 60;
		timePass = 0;
		SetCountText ();
		level = 1;
		lossText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		movement = playerControlControler.transform.TransformDirection (movement);
		rigidbody.AddForce (movement * Time.deltaTime*speed);
		SetTimeText ();
		ActivePlane ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}

	void SetTimeText()
	{
		timePass += Time.deltaTime;
		timeLeft = totalTime - (int)timePass;
		if (timeLeft <= 0) {
			Time.timeScale = 0;
			lossText.text = "You Loss";
		}
		timeText.text = "Time: " + timeLeft.ToString ();
	}

	void ActivePlane()
	{
		if( count == 4)
		{
			level2Plane.SetActive(true);
			timeLeft += 30;
		}
		if( count == 7)
		{
			level3Plane.SetActive(true);
			timeLeft += 30;
		}
	}
	
}
