using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] EnemiesData _enemyData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] IntVariables _killCount;
    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private GameObject _player;
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
        if(_currentHP<=0) { Death(); }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb2D.velocity = _direction * _enemyData._moveSpeed * Time.fixedDeltaTime;
    }

    void TakeDamage(int damage)
    {
        _currentHP-= damage;
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    void Death() { _killCount.value += 1;  DestroyEnemy(); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            TakeDamage(_playerData._attPower);
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