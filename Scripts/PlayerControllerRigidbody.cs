using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidbody : Rigidbody2DEntity {

    Animator anim;

    // Controls
    PlayerControls controls;

    // Movement
    Rigidbody2D playerRigidbody;
    Vector3 globalDir;

    // Status
    bool moving;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Move.performed += dir => SetDir(dir.ReadValue<Vector2>());
        controls.Player.Move.canceled += _ => CancelMovement();
    }

    // Use this for initialization
    void Start ()
	{
        anim = GetComponent<Animator>();

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.drag = drag;
	}

    void Update()
    {
        if (moving) Move(globalDir);
    }

    void SetDir(Vector2 dir)
    {
        moving = true;

        globalDir = dir;
    }

    // Move sprite in given direction
	void Move(Vector3 dir)
    {
		playerRigidbody.velocity = dir * speed;

		anim.SetFloat("MoveX", dir.x);
		anim.SetFloat("MoveY", dir.y);
    }

    void CancelMovement()
    {
        moving = false;

        // Cancel animator animations
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", 0);
    }

    void OnEnable() { controls.Enable(); }
    void OnDisable() { controls.Disable(); }
}
