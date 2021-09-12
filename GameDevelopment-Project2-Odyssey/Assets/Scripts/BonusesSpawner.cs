using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigForBonuses> ListOfTypeWaveConfigForBonusesScriptableObject;
    [SerializeField] int startingWave = 0; //Index 0 is the starting point. Making this serializable allows us to try different waves at start.
    int waveIndex; //This is declaring the wave counts for all waves.
    int bonusesCount; //This is declaring the enemy count for each wave.

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
        for (waveIndex = startingWave; waveIndex < ListOfTypeWaveConfigForBonusesScriptableObject.Count; waveIndex++)
        {
            var currentWave = ListOfTypeWaveConfigForBonusesScriptableObject[waveIndex];
            yield return StartCoroutine(SpawnAllBonusesInWave(currentWave));
        }

    }

    private IEnumerator SpawnAllBonusesInWave(WaveConfigForBonuses variableToHoldWaveConfig)
    {
        for (bonusesCount = 0; bonusesCount < variableToHoldWaveConfig.GetNumberOfBonuses(); bonusesCount++)
        {
            var newBonuses = Instantiate(
                        variableToHoldWaveConfig.GetBonusesPrefab(),
                        variableToHoldWaveConfig.GetWaypoints()[0].transform.position,
                        Quaternion.Euler(0, 0, 0));

            newBonuses.GetComponent<BonusesPathing>().SetWaveConfig(variableToHoldWaveConfig);

            float randomSpawnTime = UnityEngine.Random.Range(variableToHoldWaveConfig.GetMinTimeBetweenSpawns(), variableToHoldWaveConfig.GetMaxTimeBetweenSpawns());

            yield return new WaitForSeconds(randomSpawnTime);
        }
    }
}
