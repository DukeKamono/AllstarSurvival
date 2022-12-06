using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
        playerSpeed = 10;
        isGrounded = false;
        playerName = "Tester";
        rb = GetComponent<Rigidbody2D>();


        //rigidbody.velocity = playerPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);

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

			Debug.Log(playerHealth);

			lastDamageTime = Time.time;
		}
	}
}
