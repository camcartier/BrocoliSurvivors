using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] EnemiesData _enemyData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] IntVariables _killCount;
    [SerializeField] WeaponData _weaponData;
    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private GameObject _player;
    private Animator _animator;
    [Header("HP Management")]
    public int _health;
    public int _currentHP;
    private SpriteRenderer _spriterenderer;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponentInChildren<SpriteRenderer>();
        _currentHP = _health = _enemyData._maxHealth;

        _player = GameObject.Find("Player");
        _animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _player.transform.position  - transform.position;

        if (_currentHP < _health)
        {
            //_spriterenderer.color = Color.red;
            //_health= _currentHP;
            StartCoroutine(ColorChangeOnDamage());
        }
        if(_currentHP<=0) { _animator.SetTrigger("death"); }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb2D.velocity = _direction.normalized * _enemyData._moveSpeed * Time.fixedDeltaTime;
    }

    void TakeDamage(int damage)
    {
        _currentHP-= damage;
    }

    /*
    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }*/



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            TakeDamage(_playerData._attPower);
        }
        if (collision.collider.CompareTag("Axe"))
        {
            TakeDamage(_playerData._attPower* _weaponData._axePower);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Garlic"))
        {
            TakeDamage(_playerData._attPower * _weaponData._garlicPower);
        }
        if (collision.CompareTag("Water"))
        {
            TakeDamage(_playerData._attPower * _weaponData._waterPower);
        }
    }


    IEnumerator ColorChangeOnDamage()
    {
        _spriterenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        _spriterenderer.color = Color.white;
        _health = _currentHP;
    }
}
