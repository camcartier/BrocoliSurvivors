using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private IntVariables _playerHealth;
    [SerializeField] private IntVariables _scoreCounter;
    [SerializeField] private IntVariables _livesCounter;

    [SerializeField] private FloatVariables _timer;
    private float _timeElapsed;

    private void Awake()
    {
        _playerHealth.value = _playerData._maxHealth;
        _livesCounter.value = _playerData._maxLives;
        _scoreCounter.value = 0;
        _timer.value = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeElapsed < 1800)
        {
            _timeElapsed += Time.deltaTime;
            _timer.value = _timeElapsed;
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
