using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public float abilityDamage;
    public float abilitySpeed;
    //public float abilityTime;
    //public float abilityStartTime;
    //public float abilitySpeedMultiplier;
    //public float abilityTimeMultiplier;
    public float abilityDuration;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        abilityDamage = 1f;
        abilitySpeed = 5f;
        //abilityTime = 10f;
        //abilityStartTime = 5f;
        abilityDuration = 10f; // Make this per second, so we don't have stray abilies laying around.
    }

    void FixedUpdate()
	{
		Vector2 abilityVector = new Vector2(rb.position.x * abilitySpeed * Time.deltaTime, rb.position.y * abilitySpeed * Time.deltaTime).normalized;
        rb.AddForce(abilityVector);

		//      if (abilityTime <= 0)
		//{

		//          abilityTime = abilityStartTime;
		//}
		//      else
		//{
		//          abilityTime -= Time.deltaTime;
		//}
	}

	void Update()
	{
        // I don't think this is per second, but it's a start.
		abilityDuration -= Time.deltaTime;

        if (abilityDuration <= 0)
		{
            Destroy(gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(abilityDamage);
            Destroy(gameObject);
        }
    }
}
