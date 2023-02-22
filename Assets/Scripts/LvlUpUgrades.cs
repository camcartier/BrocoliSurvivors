using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LvlUpUgrades : MonoBehaviour
{
    public UnityEvent lvlUp;

    [SerializeField] PlayerData _playerData;

    private void Start()
    {
        lvlUp.AddListener(UIAppears);
    }



    void UIAppears()
    {
        Debug.Log("aaa");
    }
}
