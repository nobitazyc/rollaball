using UnityEngine;
using System.Collections;

public class PlayerControlControler : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 turn = new Vector3 (0f, Input.GetAxis ("Mouse X"), 0f);
		transform.Rotate (turn*30*Time.deltaTime);
		transform.position = player.transform.position;
	}
}
