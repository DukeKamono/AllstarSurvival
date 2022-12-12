using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private float horizontal;
	private float vertical;
    private float playerHealth;
    private float playerSpeed;
    private bool isGrounded;
    private string playerName;
    private Vector2 playerPosition;
    private Rigidbody2D rb;
	private float lastDamageTime = 0f;
	public float damagePeriod = 0.5f;


	// Start is called before the first frame update
	void Start()
    {
        playerHealth = 100;
        playerSpeed = 500;
        isGrounded = false;
        playerName = "Tester";
        rb = GetComponent<Rigidbody2D>();


		//rigidbody.velocity = playerPosition;
	}

	// Update is called once per frame
	private void Update()
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		playerPosition = new Vector2(horizontal, vertical).normalized;

		//This was to keep animation sides.
		//if (playerPosition.x != 0)
		//{
		//	lastHorizontalVector = playerPosition.x;
		//}

		//if (playerPosition.y != 0)
		//{
		//	lastVerticalVector = playerPosition.y;
		//}
	}

	// FixedUpdate() is more suited for physics calculation as it calls in regular intervals and is not based on framerate like with Update().
	void FixedUpdate()
    {
		//Vector3 tempVect = new Vector3(horizontal, vertical, 0);
		//tempVect = tempVect.normalized * playerSpeed * Time.deltaTime;
		//rb.MovePosition(rb.transform.position + tempVect);


		//Vector2 position = rb.position;
		//position.x = position.x + playerSpeed * horizontal * Time.deltaTime;
		//position.y = position.y + playerSpeed * vertical * Time.deltaTime;

		//rb.MovePosition(position);

		rb.velocity = new Vector2(playerPosition.x * playerSpeed * Time.deltaTime, playerPosition.y * playerSpeed * Time.deltaTime);

		if (!Input.anyKey)
		{
			rb.velocity = new Vector2(0, 0);
		}


		//if (Input.GetKey("left"))
		//{
		//          rb.velocity = new Vector2(-1, 0);

		//      }

		//      if (Input.GetKey("up"))
		//      {
		//          rb.velocity = new Vector2(0, 1);
		//      }

		//      if (Input.GetKey("right"))
		//      {

		//          rb.velocity = new Vector2(1, 0);
		//      }

		//      if (Input.GetKey("down"))
		//      {
		//          rb.velocity = new Vector2(0, -1);
		//      }

		//      if (!Input.anyKey)
		//{
		//          rb.velocity = new Vector2(0, 0);
		//      }
	}

	public void TakeDamage(float amount)
	{
		//Need to change times for invulnerability times. Maybe set it to player stats
		if (Time.time - lastDamageTime >= damagePeriod)
		{
			playerHealth -= amount;

			//Debug.Log(playerHealth);

			lastDamageTime = Time.time;
		}
	}
}
