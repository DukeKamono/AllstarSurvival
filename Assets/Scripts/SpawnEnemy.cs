using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject respawnPrefab;
    public float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    //public float minTime;
    public int spawnSide;

    public float cameraHeight;
    public float cameraWidth;
    public Vector3 worldPoint;

    // Start is called before the first frame update
    void Start()
    {
        startTimeBetweenSpawn = 1;
        //minTime = 0.65f;

        //Instantiate(respawnPrefab, gameObject.transform.position, gameObject.transform.rotation);
        spawnSide = Random.Range(0, 4);

        worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
        //cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            if (spawnSide == 0) //Top
            {
                //Instantiate(respawnPrefab, new Vector3(cameraWidth, Random.Range(-cameraHeight, cameraHeight), 1f), Quaternion.identity);
                Instantiate(respawnPrefab, new Vector3((worldPoint.x - cameraWidth / 2) + Random.Range(-cameraWidth / 2, cameraWidth / 2), worldPoint.y, 1f), Quaternion.identity);
            }
            else if (spawnSide == 1) //Bottom
            {
                //Instantiate(respawnPrefab, new Vector3(-cameraWidth, Random.Range(-cameraHeight, cameraHeight), 1f), Quaternion.identity);
                Instantiate(respawnPrefab, new Vector3((worldPoint.x - cameraWidth / 2) + Random.Range(-cameraWidth / 2, cameraWidth / 2), worldPoint.y - cameraHeight, 1f), Quaternion.identity);
            }
            else if (spawnSide == 2) //Right
            {
                //Instantiate(respawnPrefab, new Vector3(Random.Range(-cameraWidth, cameraWidth), cameraHeight, 1f), Quaternion.identity);
                Instantiate(respawnPrefab, new Vector3(worldPoint.x, (worldPoint.y - cameraHeight / 2) + Random.Range(-cameraHeight / 2, cameraHeight / 2), 1f), Quaternion.identity);
            }
            else if (spawnSide == 3) //Left
            {
                //Instantiate(respawnPrefab, new Vector3(Random.Range(-cameraWidth, cameraWidth), -cameraHeight, 1f), Quaternion.identity);
                Instantiate(respawnPrefab, new Vector3(worldPoint.x - cameraWidth, (worldPoint.y - cameraHeight / 2) + Random.Range(-cameraHeight / 2, cameraHeight / 2), 1f), Quaternion.identity);
            }
            timeBetweenSpawn = startTimeBetweenSpawn;
            spawnSide = Random.Range(0, 4);
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;

        worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
    }
}
