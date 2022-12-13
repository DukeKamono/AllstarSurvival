using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float speed;
    public float attackDamage;
    //public float decayDamage;
    //public float attackSpeed;
    //public float decaySpeed;
    public float hitpoints;
    public float exp;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        attackDamage = 1;
        hitpoints = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Move this later
    public void TakeDamage(float amount)
    {
        hitpoints -= amount;

        if (hitpoints <= 0)
		{
            gameObject.SetActive(false);
            Destroy(gameObject);
            
            //Give Exp
		}
    }
}
