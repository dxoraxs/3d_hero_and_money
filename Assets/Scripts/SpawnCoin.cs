using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Vector2 _barrierSpawn;
    [SerializeField] private float _positionYSpawn;
    [SerializeField] private int _numberSpawnObject;
    [SerializeField] private GameObject _coinPrefab;

    void Start()
    {
        for (int i = 0; i<_numberSpawnObject; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(transform.position.x + 2, _barrierSpawn.x - 2),
                _positionYSpawn,
                Random.Range(transform.position.z + 2, _barrierSpawn.y - 2));
            Instantiate(_coinPrefab, spawnPosition, new Quaternion(), transform);
        }
    }
}
