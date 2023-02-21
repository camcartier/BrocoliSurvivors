using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private IntVariables _playerHealth;
    [SerializeField] private IntVariables _scoreCounter;
    [SerializeField] private IntVariables _livesCounter;

    private void Awake()
    {
        _playerHealth.value = _playerData._maxHealth;
        _livesCounter.value = _playerData._maxLives;
        _scoreCounter.value = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
