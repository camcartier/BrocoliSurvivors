using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

public class Spawner : MonoBehaviour
{
    private GameObject _gameManager;
    [Header("EnemyTypes")]
    [SerializeField] GameObject _ratPrefab;
    [SerializeField] GameObject _batPrefab;
    [SerializeField] GameObject _snakePrefab;
    [SerializeField] GameObject _skelettonPrefab;

    [Header ("SpawnStats")]
    private int _numberToSpawn;
    private int _numberToSpawnInit;
    private int _activeEnemies;
    [SerializeField] float _timeMaxTillNextSpawn;

    public List<GameObject> SpawnZones = new List<GameObject>();

    private void Awake()
    {
        _numberToSpawnInit = 40;
        _numberToSpawn= _numberToSpawnInit;
        _activeEnemies = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_activeEnemies == 0)
        {
            Spawn();
            _activeEnemies = _numberToSpawn;
        }
    }

    void Spawn()
    {
        GameObject _leftspawn = SpawnZones[0];
        //Vector2 spawnpos = new Vector2(_leftspawn.transform.position.x, _leftspawn.transform.position.y);
        for (int i = 0; i<= _numberToSpawn/2; i++)
        {
            Instantiate(_batPrefab, new Vector2( _leftspawn.transform.position.x, _leftspawn.transform.position.y), Quaternion.identity);
            i++;
        }
        for (int i = 0; i <= _numberToSpawn / 2; i++)
        {
            Instantiate(_batPrefab, new Vector2(SpawnZones[1].transform.position.x, SpawnZones[1].transform.position.y), Quaternion.identity);
        }

    }
}
