using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies
{
    public GameObject enemyPrefab;
    public float timeBetweenSpawn;
    public float startTimeBetweenSpawn;

    public Enemies(string prefab, float timeBetween, float startTime)
	{
        enemyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/"+ prefab +".prefab", typeof(GameObject)) as GameObject;
        timeBetweenSpawn = timeBetween;
        startTimeBetweenSpawn = startTime;
	}
}
