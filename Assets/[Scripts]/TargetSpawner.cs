using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int numberOfTargets = 10;

    private GameObject[] targets;

    private void Start()
    {
        SpawnTargets();
    }

    private void SpawnTargets()
    {
        targets = new GameObject[numberOfTargets];

        for (int i = 0; i < numberOfTargets; i++)
        {
            // Generate random position within a range
            Vector3 randomPosition = new Vector3(Random.Range(-40f, 40f), 3f, Random.Range(25f, 95f));

            // Instantiate the target prefab at the random position
            targets[i] = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        // Check if any targets are destroyed and respawn them
        for (int i = 0; i < numberOfTargets; i++)
        {
            if (targets[i] == null)
            {
                // Generate random position within a range
                Vector3 randomPosition = new Vector3(Random.Range(-40f, 40f), 3f, Random.Range(25f, 95f));

                // Instantiate a new target prefab at the random position
                targets[i] = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
            }
        }
    }
}
