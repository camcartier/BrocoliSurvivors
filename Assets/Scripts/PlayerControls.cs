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
    private float _shootTimer = 5f;
    private float _shootTimerCounter;
    private bool _canTakeDamage = true;
    private float _invulnerabilityTimer = 1f;
    private float _invulnerabiliyTimerCounter = 0f;

    [SerializeField] IntVariables _currentHealth;
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _canonTop;
    [SerializeField] GameObject _canonBottom;
    [SerializeField] GameObject _canonLeft;
    [SerializeField] GameObject _canonRight;


    private void Awake()
    {
        _rb2D= GetComponent<Rigidbody2D>();
        _animator= GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 3f);
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
        else
        {
            _canTakeDamage = true;
            _invulnerabiliyTimerCounter = 0f;
        }
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
            
            _canTakeDamage= false;
        }

    }

    private void TakeDamage(int damage)
    {
        _currentHealth.value -= damage;
    }

    void Shoot()
    {
        Instantiate(_bulletPrefab, _canonTop.transform);
        Instantiate(_bulletPrefab, _canonBottom.transform);
        Instantiate(_bulletPrefab, _canonLeft.transform);
        Instantiate(_bulletPrefab, _canonRight.transform);
        _canShoot = false;
    }

}
