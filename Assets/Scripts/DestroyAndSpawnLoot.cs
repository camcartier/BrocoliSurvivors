using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawnLoot : MonoBehaviour
{
    [SerializeField] GameObject _loot;
    [SerializeField] IntVariables _killCount;
    [SerializeField] IntVariables _activeEnemies;
    private int _nextLevelNumber;

    private void Awake()
    {
        _nextLevelNumber = 10;
        _killCount.value = 9;
    }

    void SpawnLoot()
    {
        Instantiate(_loot, transform.position, Quaternion.identity);
    }

    void DestroyGameObject()
    {
        if (_activeEnemies.value != 0)
        {
            _activeEnemies.value -=1;
            if (_activeEnemies.value < 0)
            {
                _activeEnemies.value = 0;
            }
        }
        Destroy(transform.parent.gameObject);
    }
    void ScoreUp() {
        _killCount.value += 1;

    }

}
