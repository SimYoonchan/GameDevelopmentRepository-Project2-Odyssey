using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VexPathing : MonoBehaviour
{
    WaveConfig variableToHoldWaveConfig;

    List<Transform> waypoints;
    private int indexForPath0Waypoints = 0;


    // Start is called before the first frame update
    void Start()
    {
        //This allows us to tap into WaveConfig cs file through the variable waveConfig.
        //And so we have access to GetWaypoints() method.
        //Until the point of this code, the list is empty.
        waypoints = variableToHoldWaveConfig.GetWaypoints();

        transform.position = waypoints[indexForPath0Waypoints].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ContinueWaypointMoving();
    }

    public void SetWaveConfig(WaveConfig waveConfigSet)
    {
        this.variableToHoldWaveConfig = waveConfigSet;
    }

    private void ContinueWaypointMoving()
    {
        if (indexForPath0Waypoints < waypoints.Count)
        {
            float enemyMoveSpeed = variableToHoldWaveConfig.GetMoveSpeed();

            float enemyType1MaxDistanceDelta = enemyMoveSpeed * Time.deltaTime;

            var targetPosition = waypoints[indexForPath0Waypoints].transform.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyType1MaxDistanceDelta);

            if (transform.position == targetPosition)
            {
                indexForPath0Waypoints++;
            }
        }

        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}

