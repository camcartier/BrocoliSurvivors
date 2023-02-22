using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawnLoot : MonoBehaviour
{
    [SerializeField] GameObject _loot;
    [SerializeField] IntVariables _killCount;
    [SerializeField] IntVariables _activeEnemies;
    private LvlUpUgrades _lvlUpUpgrades;

    private void Awake()
    {
        _lvlUpUpgrades = GameObject.Find("UpgradeManager").GetComponent<LvlUpUgrades>();
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
        if (_killCount.value == 10)
        {
            _lvlUpUpgrades.GetComponent<LvlUpUgrades>().lvlUp.Invoke();
        }

    }

}
