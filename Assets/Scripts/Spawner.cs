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

    [SerializeField] IntVariables _activeEnemies;

    [Header ("SpawnStats")]
    private int _numberToSpawn;
    private int _numberToSpawnInit;
    //private int _activeEnemies;
    private int _wave;
    //private bool _hasSpawned;
    //private bool _spawncleared;
    [SerializeField] float _timeMaxTillNextSpawn;

    public List<GameObject> SpawnZones = new List<GameObject>();

    private void Awake()
    {
        _numberToSpawnInit = 40;
        _numberToSpawn= _numberToSpawnInit * _wave;
        _activeEnemies.value = 0;

        _wave = 1;
        //_hasSpawned= false;
        //_spawncleared = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (_activeEnemies.value == 0)
        {
            Spawn();
            //_hasSpawned = true;   
            _wave++;
        }


        //_activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;


    }

    void Spawn()
    {
        _numberToSpawn = (_numberToSpawnInit * _wave)/2;
        GameObject _leftspawn = SpawnZones[0];
        GameObject _rightSpawn  = SpawnZones[1];
        //Vector2 spawnpos = new Vector2(_leftspawn.transform.position.x, _leftspawn.transform.position.y);
        for (int i = 0; i<= _numberToSpawn; i++)
        {
            Instantiate(_batPrefab, new Vector2( _leftspawn.transform.position.x, _leftspawn.transform.position.y), Quaternion.identity);
            Instantiate(_batPrefab, new Vector2(_rightSpawn.transform.position.x, _rightSpawn.transform.position.y), Quaternion.identity);
            i++;
        }

        _activeEnemies.value = _numberToSpawn;
        //Debug.Log($"{_activeEnemies}");
    }




    void GetNumberActive()
    {
        _activeEnemies.value = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log($"{_activeEnemies.value}");
    }
}
