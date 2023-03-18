using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;
	//public Animator animator;

	//private bool facingLeft;

	public Camera cam;

	Vector2 movement;
	Vector2 mousePos;

	void Update()
	{
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		/*animator.SetFloat("Horizontal",movement.x);
		animator.SetFloat("Vertical",movement.y);
		animator.SetFloat("Speed",movement.sqrMagnitude);*/

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	}

	// Melhor para trabalhar com física	
	void FixedUpdate()
	{
		// Movement
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
	}

}
