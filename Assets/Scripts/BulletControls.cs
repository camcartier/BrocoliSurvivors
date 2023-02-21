using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletControls : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private GameObject _playerBody;

    [SerializeField] private int _bulletSpeed;
    private Vector2 _direction;
    [SerializeField] private Vector2 _force = new Vector2(10,10);


    private void Awake()
    {
        _rb2D= GetComponent<Rigidbody2D>();
        _playerBody = GameObject.Find("PlayerBody");
    }

    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.position - _playerBody.transform.position;
        _rb2D.AddForce(_direction * _force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
