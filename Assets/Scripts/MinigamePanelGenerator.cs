using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePanelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab; 
    [SerializeField] private RectTransform _panelRect; 
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _borderY;
    [SerializeField] private float _borderX;
    private GameObject currentObject;

    private void Start()
    {
        StartCoroutine(SpawnObjectsRoutine());
    }

    private IEnumerator SpawnObjectsRoutine()
    {
        yield return new WaitForSeconds(_spawnInterval);
        while (true)
        {
            if (currentObject == null)
            {
                Vector2 randomPosition = GetRandomPositionInPanel();
                currentObject = Instantiate(_objectPrefab, randomPosition, Quaternion.identity, _panelRect);
                yield return new WaitForSeconds(_spawnInterval);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    Vector2 GetRandomPositionInPanel()
    {
        float randomX = Random.Range(150, _borderX);
        float randomY = Random.Range(150, _borderY);
        return new Vector2(randomX, randomY);
    }
}
