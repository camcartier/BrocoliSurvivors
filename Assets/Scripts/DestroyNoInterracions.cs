using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNoInterracions : MonoBehaviour
{
    private float _destructionTimer = 5;
    private float _destructionTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_destructionTimeCounter< _destructionTimer)
        {
            _destructionTimeCounter += Time.deltaTime;
        }
        else { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundaries"))
        {
            Destroy(gameObject);
        }
    }

}
