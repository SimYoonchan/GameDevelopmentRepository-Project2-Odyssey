using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonuses Wave Config")]

public class WaveConfigForBonuses : ScriptableObject
{
    [SerializeField] GameObject bonusesPrefab; //Still have to drag in Wave Config file.
    [SerializeField] GameObject pathPrefab; //Still have to drag in Wave Config file.
    [SerializeField] float minTimeBetweenSpawns; //Input in Unity for flexibility.
    [SerializeField] float maxTimeBetweenSpawns; //Input in Unity for flexibility.
    [SerializeField] int numberOfBonuses; //Input in Unity for flexibility.
    [SerializeField] float moveSpeed;

    public GameObject GetBonusesPrefab()
    {
        return bonusesPrefab;
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

    public int GetNumberOfBonuses()
    {
        return numberOfBonuses;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
