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
    private int _wave = 1;
    private bool _hasSpawned;
    [SerializeField] float _timeMaxTillNextSpawn;

    public List<GameObject> SpawnZones = new List<GameObject>();

    private void Awake()
    {
        _numberToSpawnInit = 40;
        _numberToSpawn= _numberToSpawnInit * _wave;
        _activeEnemies = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        _numberToSpawn = _numberToSpawnInit * _wave;
    }

    // Update is called once per frame
    void Update()
    {
        _numberToSpawn = _numberToSpawnInit * _wave;
        if (_activeEnemies == 0 && !_hasSpawned)
        {
            Spawn();
            _hasSpawned = true;
            _wave++;
        }
        //_activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (_hasSpawned && _activeEnemies == 0)
        {
            Spawn();
            _hasSpawned = false;
            _wave++;
        }
    }

    void Spawn()
    {
        GameObject _leftspawn = SpawnZones[0];
        GameObject _rightSpawn  = SpawnZones[1];
        //Vector2 spawnpos = new Vector2(_leftspawn.transform.position.x, _leftspawn.transform.position.y);
        for (int i = 0; i<= _numberToSpawn/2; i++)
        {
            Instantiate(_batPrefab, new Vector2( _leftspawn.transform.position.x, _leftspawn.transform.position.y), Quaternion.identity);
            Instantiate(_batPrefab, new Vector2(_rightSpawn.transform.position.x, _rightSpawn.transform.position.y), Quaternion.identity);
            i++;
        }
        _activeEnemies = _numberToSpawn;

        Debug.Log($"{_activeEnemies}");
    }
}
