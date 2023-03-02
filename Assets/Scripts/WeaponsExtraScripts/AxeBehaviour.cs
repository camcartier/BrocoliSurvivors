using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
    private float _posX =1;
    private float _posY =1;
    private float _rotationZValue;
    private float _forceX;
    private float _forceY;
    private Rigidbody2D _rb2D;

    private int _numberOfCollisions;

    [SerializeField] WeaponData _weaponData;

    private void Awake()
    {
        _rb2D= GetComponent<Rigidbody2D>();
        _rb2D.velocity= Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 RandomForce = new Vector2(_posX*Random.Range(-4*30,4* 30), _posY * Random.Range(8* 30, 17* 30));
        _rb2D.AddForce(RandomForce,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberOfCollisions > _weaponData._nbCollisionsBeforeDestroy)
        {
            Destroy(gameObject);
        }

        //Transform.Rotate(gameObject, );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            _numberOfCollisions++;
        }
    }
}
