using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawnLoot : MonoBehaviour
{
    [SerializeField] GameObject _loot;
    [SerializeField] IntVariables _killCount;

    void SpawnLoot()
    {
        Instantiate(_loot, transform.position, Quaternion.identity);
    }

    void DestroyGameObject()
    {
        Destroy(transform.parent.gameObject);
    }
    void ScoreUp() { _killCount.value += 1; }

}
