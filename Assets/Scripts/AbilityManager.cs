using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    //public GameObject abilityPrefab;
    public List<GameObject> abilities;
    //private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<GameObject>();
		//abilityPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Ability1.prefab", typeof(GameObject)) as GameObject;
		//playerRigidBody = GetComponent<Rigidbody2D>();
		//Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
	}

	// Update is called once per frame
	void Update()
    {
  //      foreach (var ability in abilities)
		//{
  //          ability.gameObject.SetActive(true);
		//}
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ability"))
        {
            addAbility(collision.gameObject);
        }
    }

    void addAbility(GameObject ability)
	{
        abilities.Add(ability);
	}
}
