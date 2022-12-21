using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LeftBullet : MonoBehaviour
{
    private Ability attributes;
    private Rigidbody2D playerRigidBody;
    private GameObject abilityPrefab;
    private float abilityTime;


    // Start is called before the first frame update
    void Start()
    {
        attributes = new Ability(1f, 1f, 5f, "LeftBullet", "Assets/Prefabs/Ability1.prefab", new Vector2(-10f, 0f));
        playerRigidBody = GetComponent<Rigidbody2D>();
        abilityPrefab = AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityTime <= 0)
        {
            var bullet = Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x - 0.5f, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(attributes.momentum.x - Mathf.Abs(playerRigidBody.velocity.x), 0.0f);
            abilityTime = attributes.cooldown;
        }
        else
        {
            abilityTime -= Time.deltaTime;
        }
    }
}