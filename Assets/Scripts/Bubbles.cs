using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bubbles : MonoBehaviour
{
    private Ability attributes;
    private Rigidbody2D playerRigidBody;
    private GameObject abilityPrefab;
    private float abilityTime;
    public float abilitySpeed;


    // Start is called before the first frame update
    void Start()
    {
        attributes = gameObject.AddComponent<Ability>();
        
        attributes.rarity = 1f;
        attributes.cooldown = 1f;
        attributes.power = 5f;
        attributes.skillName = "Bubbles";
        attributes.sprite = "Assets/Prefabs/Ability1.prefab";
        attributes.momentum = new Vector2(0f, -10f);

        abilitySpeed = 5f;

        playerRigidBody = GetComponent<Rigidbody2D>();
        CreateParticle();
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityTime <= 0)
        {
            Destroy(abilityPrefab);
            CreateParticle();
        }
        else
        {
            abilityTime -= Time.deltaTime;
        }
    }

    void CreateParticle()
	{
        abilityPrefab = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
        var rb = abilityPrefab.GetComponent<Rigidbody2D>();
        //This gives it a floaty effect like bubbles. Might save later. or it did.
        Vector2 abilityVector = new Vector2(rb.position.x * abilitySpeed * Time.deltaTime, rb.position.y * abilitySpeed * Time.deltaTime).normalized;
        rb.AddForce(abilityVector);

        abilityTime = attributes.cooldown;
    }
}