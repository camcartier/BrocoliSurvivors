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

    private void Awake()
    {
        _rb2D= GetComponent<Rigidbody2D>();
        _rb2D.velocity= Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 RandomForce = new Vector2(_posX*Random.Range(-4*10,4*10), _posY * Random.Range(8*10, 17*10));
        _rb2D.AddForce(RandomForce,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //Transform.Rotate(gameObject, );
    }

}
