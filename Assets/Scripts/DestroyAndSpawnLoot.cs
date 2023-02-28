using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawnLoot : MonoBehaviour
{
    [Header("Loots")]
    [SerializeField] GameObject _commonLoot;
    [SerializeField] GameObject _rareLoot;
    [SerializeField] GameObject _legendaryLoot;
    [Header("Enemies")]
    [SerializeField] IntVariables _killCount;
    [SerializeField] IntVariables _activeEnemies;

    private List<GameObject> ListOfPossibleLoot = new List<GameObject>();

    private void Awake()
    {
        ListOfPossibleLoot.Clear();
    }

    void SpawnLoot()
    {
        //la liste servira plus tard
        ListOfPossibleLoot.Add(_commonLoot); ListOfPossibleLoot.Add(_rareLoot); ListOfPossibleLoot.Add(_legendaryLoot);
        Instantiate(_commonLoot, transform.position, Quaternion.identity);
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
