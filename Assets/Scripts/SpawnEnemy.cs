using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject respawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(respawnPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
