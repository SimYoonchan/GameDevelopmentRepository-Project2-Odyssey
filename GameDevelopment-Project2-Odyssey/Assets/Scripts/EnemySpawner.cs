using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> ListOfTypeWaveConfigScriptableObject;
    [SerializeField] int startingWave = 0; //Index 0 is the starting point. Making this serializable allows us to try different waves at start.
    int waveIndex; //This is declaring the wave counts for all waves.
    int enemyCount; //This is declaring the enemy count for each wave.

    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }

        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (waveIndex = startingWave; waveIndex < ListOfTypeWaveConfigScriptableObject.Count; waveIndex++)
        {
            var currentWave = ListOfTypeWaveConfigScriptableObject[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig variableToHoldWaveConfig)
    {
        for (enemyCount = 0; enemyCount < variableToHoldWaveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                        variableToHoldWaveConfig.GetEnemyPrefab(),
                        variableToHoldWaveConfig.GetWaypoints()[0].transform.position,
                        Quaternion.Euler(0,0,-90));

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(variableToHoldWaveConfig);

            float randomSpawnTime = UnityEngine.Random.Range(variableToHoldWaveConfig.GetMinTimeBetweenSpawns(), variableToHoldWaveConfig.GetMaxTimeBetweenSpawns());

            yield return new WaitForSeconds(randomSpawnTime);
        }
    }
}
