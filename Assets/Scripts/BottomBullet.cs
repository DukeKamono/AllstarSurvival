using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BottomBullet : MonoBehaviour
{
    private Ability attributes;
    private Rigidbody2D playerRigidBody;
    private List<GameObject> abilityPrefabs;
    private float abilityTime;


    // Start is called before the first frame update
    void Start()
    {
        attributes = gameObject.AddComponent<Ability>();
        
        attributes.rarity = 1f;
        attributes.cooldown = 1f;
        attributes.power = 5f;
        attributes.skillName = "BottomBullet";
        attributes.sprite = "Assets/Prefabs/Ability1.prefab";
        attributes.momentum = new Vector2(0f, -10f);

        abilityPrefabs = new List<GameObject>();

        playerRigidBody = GetComponent<Rigidbody2D>();
        CreateParticle();
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityTime <= 0)
        {
            foreach(var ability in abilityPrefabs)
			{
                Destroy(ability);
            }

            CreateParticle();
        }
        else
        {
            abilityTime -= Time.deltaTime;
        }
    }

    void CreateParticle()
    {
        var bullet = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.5f, 1f), Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        var bullet2 = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.6f, 1f), Quaternion.identity);
        var rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        var bullet3 = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.7f, 1f), Quaternion.identity);
        var rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        var bullet4 = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.8f, 1f), Quaternion.identity);
        var rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        var bullet5 = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 0.9f, 1f), Quaternion.identity);
        var rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb5.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        var bullet6 = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y - 1.0f, 1f), Quaternion.identity);
        var rb6 = bullet6.GetComponent<Rigidbody2D>();
        rb6.velocity = new Vector2(0.0f, attributes.momentum.y - Mathf.Abs(playerRigidBody.velocity.y));

        abilityPrefabs.Add(bullet);
        abilityPrefabs.Add(bullet2);
        abilityPrefabs.Add(bullet3);
        abilityPrefabs.Add(bullet4);
        abilityPrefabs.Add(bullet5);
        abilityPrefabs.Add(bullet6);

        abilityTime = attributes.cooldown;
    }
}