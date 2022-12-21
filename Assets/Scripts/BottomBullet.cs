using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BottomBullet : MonoBehaviour
{
    private Ability attributes;
    private Rigidbody2D playerRigidBody;
    private GameObject abilityPrefab;
    private float abilityTime;


    // Start is called before the first frame update
    void Start()
    {
        attributes = new Ability(1f, 1f, 5f, "BottomBullet", "Assets/Prefabs/Ability1.prefab", new Vector2(0f, -10f));
        playerRigidBody = GetComponent<Rigidbody2D>();
        abilityPrefab = AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityTime <= 0)
        {
            var bullet = Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.5f, 1f), Quaternion.identity);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));
            abilityTime = attributes.cooldown;
        }
        else
        {
            abilityTime -= Time.deltaTime;
        }
    }
}