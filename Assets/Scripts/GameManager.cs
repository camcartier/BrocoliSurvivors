using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private IntVariables _playerHealth;
    [SerializeField] private IntVariables _killCounter;
    [SerializeField] private IntVariables _livesCounter;
    [SerializeField] private IntVariables _expCount;

    [SerializeField] private FloatVariables _timer;
    private float _timeElapsed;

    private bool _isPaused;
    private bool _isPlaying;
    [Header("Pause")]
    [SerializeField] GameObject _pausePanel;

    [Header("Continue")]
    [SerializeField] GameObject _continuePanel;

    [Header("LevelUp")]
    [SerializeField] GameObject _levelUpPanel;

    private int _expForNextLevel;

    private void Awake()
    {
        _playerHealth.value = _playerData._maxHealth;
        _livesCounter.value = _playerData._maxLives;
        _killCounter.value = 0;
        _timer.value = 0;

        _expForNextLevel = 5;
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

        if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == false)
        {
            PauseGame();
            _pausePanel.SetActive(true);
        }

        /*
        if (_killCounter.value == 10)
        {
            //_lvlUpUpgrades.GetComponent<LvlUpUgrades>().lvlUp.Invoke();
        }*/

        if (_expCount.value >= _expForNextLevel)
        {
            LevelUp();
        }

    }


    public void LevelUp()
    {
        Time.timeScale = 0;
        _levelUpPanel.SetActive(true);
        _expForNextLevel *= 2;
    }

    public void Revive()
    {
        _continuePanel.SetActive(false);
        _playerHealth.value = _playerData._maxHealth/2;
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void SendContinuePanel()
    {
        _continuePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("resume game");
        Time.timeScale = 1;
        _isPaused = false;
        if (_pausePanel.activeSelf)
        {
            _pausePanel.SetActive(false);
        }
        if (_levelUpPanel.activeSelf)
        {
            _levelUpPanel.SetActive(false);
        }
    }

    public void GetToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        _pausePanel.SetActive(false);
    }
}
