using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity {

    private Animator anim; 

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime; 
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )
        {
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed *Time.deltaTime; 
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime; 
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )
        {
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime; 
		}

        anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxis("Vertical")); 
	}
}
