using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("GarlicData")]
    public float _garlicPower;
    public bool _activateGarlic;
    [SerializeField] Transform _garlicSize;
    [SerializeField] GameObject _garlicFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Garlic()
    {
        _garlicFX.SetActive(true);
        _activateGarlic = true;
    }

}
