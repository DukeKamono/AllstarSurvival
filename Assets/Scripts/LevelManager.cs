using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    public List<Enemies> LoadLevel()
	{
        var sceneName = SceneManager.GetActiveScene().name;
        var enemyList = new List<Enemies>();

        if (sceneName == "Level1")
		{
            enemyList.Add(new Enemies("EnemyType1", 10, 10));
            enemyList.Add(new Enemies("EnemyType2", 5, 5));
            enemyList.Add(new Enemies("EnemyType3", 15, 15));
            enemyList.Add(new Enemies("EnemyType4", 20, 20));

            return enemyList;
		}
        else
		{
            return enemyList;
        }
    }
}
