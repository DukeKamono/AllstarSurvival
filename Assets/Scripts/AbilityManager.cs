using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject abilityPrefab;
    public List<GameObject> abilites;
    private Rigidbody2D playerRigidBody;

    public float abilityTime;
    public float abilityStartTime;

    // Start is called before the first frame update
    void Start()
    {
        //abilites = new List<GameObject>();

        //
        abilityPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Ability1.prefab", typeof(GameObject)) as GameObject;

        playerRigidBody = GetComponent<Rigidbody2D>();
        //Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);

        abilityTime = 1f;
        abilityStartTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityTime <= 0)
        {
            Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x + 1f, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
            Instantiate(abilityPrefab, new Vector3(playerRigidBody.gameObject.transform.position.x - 1f, playerRigidBody.gameObject.transform.position.y, 1f), Quaternion.identity);
            abilityTime = abilityStartTime;
        }
        else
        {
            abilityTime -= Time.deltaTime;
        }
    }
}
