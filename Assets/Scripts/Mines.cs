using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Mines : MonoBehaviour
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
        attributes.cooldown = 5f;
        attributes.power = 5f;
        attributes.skillName = "Mines";
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
            foreach (var ability in abilityPrefabs)
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
        var leftMine = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x + 1f, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
        var rightMine = Instantiate(AssetDatabase.LoadAssetAtPath(attributes.sprite, typeof(GameObject)) as GameObject, new Vector3(playerRigidBody.gameObject.transform.position.x - 1f, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);

        abilityPrefabs.Add(leftMine);
        abilityPrefabs.Add(rightMine);

        abilityTime = attributes.cooldown;
    }
}