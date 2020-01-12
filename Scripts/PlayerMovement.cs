using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//public bool isIdle, isWalk;
	private Animator anim;
	public float moveSpeed = 20;
	//private float maxSpeed;
	[HideInInspector]
	public bool facingRight = true;
	public string HorizontalAxis = "Horizontal";
	public string VerticalAxis = "Vertical";
	public string fireAxis = "Fire1";
	// Use this for initialization
	void Start () {
		if (transform.localScale.x < 0) {
			facingRight = false;
		}
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isIdleShoot", false);
		anim.SetBool ("isWalkShoot", false);
	}
	bool isIdle(){
		if (Input.GetAxis (HorizontalAxis) == 0 && Input.GetAxis (VerticalAxis) == 0) {
			//anim.SetBool ("isIdle", true);
			return true;
		} 
		return false;
	}
	bool isWalk(){
		if(Input.GetAxis (HorizontalAxis) != 0 ||  Input.GetAxis (VerticalAxis) != 0){
			//anim.SetBool ("isWalk", true);
			return true;
		}
		return false;
	}

	bool isShoot(){
		if (Input.GetButton (fireAxis)) {
			//anim.SetBool ("isShoot", true);
			return true;
		} 
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Animation Handling
		if (isIdle()) {
			anim.SetBool ("isIdle", true);
		}
		if (!isIdle()) {
			anim.SetBool ("isIdle", false);
		}
		if (isWalk()) {
			anim.SetBool ("isWalk", true);
		}
		if (!isWalk()) {
			anim.SetBool ("isWalk", false);
		}
		if (isIdle() && isShoot()) {
			anim.SetBool ("isIdleShoot", true);
		}
		if (!isIdle() && !isShoot()) {
			anim.SetBool ("isIdleShoot", false);
		}
		if (isWalk() && isShoot()) {
			anim.SetBool ("isWalkShoot", true);
		}
		if (!isWalk() && !isShoot()) {
			anim.SetBool ("isWalkShoot", false);
		}
		if (Input.GetButtonUp ("Fire1")) {
			anim.SetBool ("isIdleShoot", false);
			anim.SetBool ("isWalkShoot", false);
		}

		// Player Movemenet
		Vector3 position = transform.position;

		position.x += Input.GetAxis (HorizontalAxis) * moveSpeed * Time.deltaTime;
		position.y += Input.GetAxis (VerticalAxis) * moveSpeed * Time.deltaTime;

		// Restricting Player to the map
		position.y = Mathf.Clamp (position.y, -42, 42);
		position.x = Mathf.Clamp (position.x, -50, 50);
		transform.position = position;


	}

	void LateUpdate() {
		if ((Input.GetAxis (HorizontalAxis) < 0 && facingRight) ||
			(Input.GetAxis (HorizontalAxis) > 0 && !facingRight)) {
			Vector3 flippyflop = transform.localScale;
			facingRight = !facingRight;
			flippyflop.x *= -1;
			transform.localScale = flippyflop;
		}
	}
}
