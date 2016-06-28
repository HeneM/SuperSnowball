using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject snowball;

	public float shotDelay;
	private float shotDelayCounter;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
	
		if (grounded)
			doubleJumped = false;


		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			//Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			//Jump ();
			doubleJumped = true;
		}	

		moveVelocity = 0f;

		if (Input.GetKey (KeyCode.D)) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.A)) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}
	
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
			}


		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (0.35f, 0.38f, 0.3f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-0.35f, 0.38f, 0.3f);
	
		if (Input.GetKeyDown (KeyCode.K))
		{
			Instantiate (snowball, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}

		if (Input.GetKey (KeyCode.K)) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (snowball, firePoint.position, firePoint.rotation);
			}
		

			//public void Jump()
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			}
		}
	}
}