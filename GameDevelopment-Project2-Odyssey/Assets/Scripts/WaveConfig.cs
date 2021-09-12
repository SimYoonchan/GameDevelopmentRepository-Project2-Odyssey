using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
//So all Scriptable Object files created with this "Enemy Wave Config" will have all of these config parameters.


public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab; //Still have to drag in Wave Config file.
    [SerializeField] GameObject pathPrefab; //Still have to drag in Wave Config file.
    [SerializeField] float minTimeBetweenSpawns; //Input in Unity for flexibility.
    [SerializeField] float maxTimeBetweenSpawns; //Input in Unity for flexibility.
    [SerializeField] int numberOfEnemies; //Input in Unity for flexibility.
    [SerializeField] float moveSpeed;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetMinTimeBetweenSpawns()
    {
        return minTimeBetweenSpawns;
    }

    public float GetMaxTimeBetweenSpawns()
    {
        return maxTimeBetweenSpawns;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
