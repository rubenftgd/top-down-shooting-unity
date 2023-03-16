using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;
	public Animator animator;

	//private bool facingLeft;

	Vector2 movement;

	void Update()
	{
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal",movement.x);
		animator.SetFloat("Vertical",movement.y);
		animator.SetFloat("Speed",movement.sqrMagnitude);
	}

	// Melhor para trabalhar com física	
	void FixedUpdate()
	{
		// Movement
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

		/*if (movement.x > 0 && !facingLeft){
			Flip();
		}
		else if (movement.x < 0 && facingLeft){
			Flip();
		}*/
	}

	/*void Flip(){
		facingLeft = !facingLeft;

		Vector2 currentScale = transform.localScale;
		currentScale.x = -1;
		transform.localScale = currentScale;
	}*/
}
