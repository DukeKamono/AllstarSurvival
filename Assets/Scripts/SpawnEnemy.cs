using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
	//public GameObject enemyPrefab;
    //public List<GameObject> enemyPrefabs;
    //public float timeBetweenSpawn;
    //public float startTimeBetweenSpawn;
    public float decreaseTime;
    //public float minTime;
    public int spawnSide;

    public float cameraHeight;
    public float cameraWidth;
    public Vector3 worldPoint;

    private List<Enemies> enemies;

    // Start is called before the first frame update
    void Start()
    {
        //enemyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyType1.prefab", typeof(GameObject)) as GameObject;
        //enemyPrefabs = new List<GameObject>
        //{
        //    AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyType1.prefab", typeof(GameObject)) as GameObject,
        //    AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyType2.prefab", typeof(GameObject)) as GameObject,
        //    AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyType3.prefab", typeof(GameObject)) as GameObject,
        //    AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyType4.prefab", typeof(GameObject)) as GameObject,
        //};

        enemies = new LevelManager().LoadLevel();

        //startTimeBetweenSpawn = 1;
        //minTime = 0.65f;

        //Instantiate(respawnPrefab, gameObject.transform.position, gameObject.transform.rotation);
        //spawnSide = Random.Range(0, 4);

        worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
        //cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemies enemy in enemies)
        {
            if (enemy.timeBetweenSpawn <= 0)
            {
                spawnSide = Random.Range(0, 4);
                if (spawnSide == 0) //Top
                {
                    //Instantiate(respawnPrefab, new Vector3(cameraWidth, Random.Range(-cameraHeight, cameraHeight), 1f), Quaternion.identity);
                    Instantiate(enemy.enemyPrefab, new Vector3((worldPoint.x - cameraWidth / 2) + Random.Range(-cameraWidth / 2, cameraWidth / 2), worldPoint.y, 1f), Quaternion.identity);
                }
                else if (spawnSide == 1) //Bottom
                {
                    //Instantiate(respawnPrefab, new Vector3(-cameraWidth, Random.Range(-cameraHeight, cameraHeight), 1f), Quaternion.identity);
                    Instantiate(enemy.enemyPrefab, new Vector3((worldPoint.x - cameraWidth / 2) + Random.Range(-cameraWidth / 2, cameraWidth / 2), worldPoint.y - cameraHeight, 1f), Quaternion.identity);
                }
                else if (spawnSide == 2) //Right
                {
                    //Instantiate(respawnPrefab, new Vector3(Random.Range(-cameraWidth, cameraWidth), cameraHeight, 1f), Quaternion.identity);
                    Instantiate(enemy.enemyPrefab, new Vector3(worldPoint.x, (worldPoint.y - cameraHeight / 2) + Random.Range(-cameraHeight / 2, cameraHeight / 2), 1f), Quaternion.identity);
                }
                else if (spawnSide == 3) //Left
                {
                    //Instantiate(respawnPrefab, new Vector3(Random.Range(-cameraWidth, cameraWidth), -cameraHeight, 1f), Quaternion.identity);
                    Instantiate(enemy.enemyPrefab, new Vector3(worldPoint.x - cameraWidth, (worldPoint.y - cameraHeight / 2) + Random.Range(-cameraHeight / 2, cameraHeight / 2), 1f), Quaternion.identity);
                }
                enemy.timeBetweenSpawn = enemy.startTimeBetweenSpawn;
            }
            else
            {
                enemy.timeBetweenSpawn -= Time.deltaTime;
            }

            cameraHeight = Camera.main.orthographicSize * 2;
            cameraWidth = cameraHeight * Camera.main.aspect;

            worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        }
    }
}
