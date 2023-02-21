using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] EnemiesData _enemyData;
    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private GameObject _player;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb2D.velocity = _direction * _enemyData._moveSpeed * Time.fixedDeltaTime;
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
