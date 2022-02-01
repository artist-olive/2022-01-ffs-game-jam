using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Seed;
    [SerializeField] private float rightBound = 0.3f;
    [SerializeField] private float leftBound = -14f;
    [SerializeField] private float upperBound = 8.6f;
    [SerializeField] private float frontBound = -4f;
    [SerializeField] private float backBound = 4f;
    [SerializeField] private float seedSpawnProbability = 0.3f;

    void Start()
    {
        StartCoroutine("HandleRandomSeedSpawn");
    }
    private IEnumerator HandleRandomSeedSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            bool shouldSpawnSeed = Random.Range(0f, 1f) <= seedSpawnProbability;
            if (shouldSpawnSeed)
            {
                SpawnSeed();
            }
        }
    }

    private void SpawnSeed()
    {
        float RandomX = Random.Range(leftBound, rightBound);
        float RandomZ = Random.Range(frontBound, backBound);
        Instantiate(Seed, new Vector3(RandomX, upperBound, RandomZ), Quaternion.identity);
    }
}
