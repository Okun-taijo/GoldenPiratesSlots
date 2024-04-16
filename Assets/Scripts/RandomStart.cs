using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStart : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private int _obstaclesCount;
    void Start()
    {
        SpawnObstacles();
    }

   private void SpawnObstacles()
    {
        for (int i = 0; i < _obstaclesCount; i++)
        {
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-1f, 3f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            Instantiate(_obstacle, spawnPosition, Quaternion.identity);
        }
    }
}
