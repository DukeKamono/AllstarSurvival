using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float enemySpeed;
    private EnemyStats stats;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        Vector3 playerVector = new Vector3(player.transform.position.x, player.transform.position.y, 1);
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, playerVector, stats.speed * Time.deltaTime);
    }

    //I had to set player to Kinematic and the enemy to Dynamic with x/y/z roation freezed for them to overlap.
    void OnCollisionStay2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        //if (collision.gameObject.name == "MyGameObjectName")
        //{
        //    //If the GameObject's name matches the one you suggest, output this message in the console
        //    Debug.Log("Do something here");
        //}

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (player.CompareTag(collision.gameObject.tag))
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Do something else here");

            player.GetComponent<PlayerScript>().TakeDamage(stats.attackDamage);
            rb.velocity = new Vector2(0, 0);
        }




        //if (collision.gameObject.tag == "RechargePoint")
        //{
        //    batteryLevel = Mathf.Min(batteryLevel + rechargeRate * Time.deltaTime, 100.0f);
        //}

    }
}
