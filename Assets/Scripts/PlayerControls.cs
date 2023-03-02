using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private Vector2 _move;
    private float _horizontal;
    private float _vertical;

    private bool _canShoot = true;
    //private float _shootTimer = 5f;
    //private float _shootTimerCounter;
    #region take damage infos
    private bool _canTakeDamage = true;
    private SpriteRenderer _spriteRenderer;
    private float _redDuration = 0.25f;
    private float _redDurationCounter;
    private bool _isRed;
    private float _invulnerabilityTimer = 0.25f;
    private float _invulnerabiliyTimerCounter = 0f;
    #endregion

    [Header ("Health")]
    [SerializeField] IntVariables _currentHealth;
    [SerializeField] IntVariables _livesNumber;
    [SerializeField] PlayerData _playerData;
    [SerializeField] WeaponData _weaponData;

    [Header("Shooting")]
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _canonTop;
    [SerializeField] GameObject _canonBottom;
    [SerializeField] GameObject _canonLeft;
    [SerializeField] GameObject _canonRight;
    [SerializeField] AudioSource _fireSound;

    [Header("boolWeapons")]
    public bool _garlicActivated;
    public bool _waterActivated;
    public bool _thunderActivated;

    private GameObject _gameManager;
    private GameObject _upgradeManager;

    #region testing
    private float timerthunder = 5;
    private float timerthunderCounter;
    #endregion

    [HideInInspector]
    public WeaponsBehaviour _weaponBehaviour;

    private void Awake()
    {
        _rb2D= GetComponent<Rigidbody2D>();
        _animator= GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager");

        _weaponBehaviour = GameObject.Find("WeaponBehaviour").GetComponent<WeaponsBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, _playerData._fireRate);

        //_upgradeManager.GetComponent<WeaponsBehaviour>().HolyWater();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();



        /*if (_canShoot)
        {
            Shoot();
        }*/

        if(_rb2D.velocity.x >0 || _rb2D.velocity.y >0 )
        {
            _animator.SetBool("walking", true);
        }
        else { _animator.SetBool("walking", false); }


        if(!_canTakeDamage && _invulnerabiliyTimerCounter < _invulnerabilityTimer)
        {
            _invulnerabiliyTimerCounter+= Time.deltaTime;
        }
        else { _canTakeDamage = true; _invulnerabiliyTimerCounter = 0f; }


        if (_isRed && _redDurationCounter < _redDuration) { _redDurationCounter += Time.deltaTime; } 
        else { _isRed = false; _spriteRenderer.color = Color.white; _redDurationCounter = 0; }


        if (_currentHealth.value <= 0)
        {
            Death();
        }

        //if (timerthunderCounter < timerthunder) { timerthunderCounter += Time.deltaTime; }
        //else { _upgradeManager.GetComponent<WeaponsBehaviour>().Thunder(); timerthunderCounter = 0; }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }





    void Move()
    {
        _move = new Vector2(_horizontal, _vertical).normalized;
        _rb2D.velocity = _move * _playerData._moveSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_canTakeDamage && collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
            _canTakeDamage = false;
        }
    }

    private void TakeDamage(int damage)
    {
        _currentHealth.value -= damage;
        _spriteRenderer.color = Color.red;
        Debug.Log("red");
        _isRed = true;
    }

    void Shoot()
    {
        Instantiate(_bulletPrefab, _canonTop.transform);
        Instantiate(_bulletPrefab, _canonBottom.transform);
        Instantiate(_bulletPrefab, _canonLeft.transform);
        Instantiate(_bulletPrefab, _canonRight.transform);
        _fireSound.Play();

        _weaponBehaviour.Upgrade.Invoke();

        _canShoot = false;
    }

    void Death()
    {
        _livesNumber.value -= 1;
        _gameManager.GetComponent<GameManager>().SendContinuePanel();
    }
}
