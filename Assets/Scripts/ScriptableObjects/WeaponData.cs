using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    [Header("Garlic")]
    [SerializeField] float _garlicPower;
    [SerializeField] float _garlicSize;
    [SerializeField] bool _isActiveGarlic;

    [Header("BlessedWater")]
    [SerializeField] float _waterPower;
    [SerializeField] float _waterSize;
    [SerializeField] float _waterDuration;
    [SerializeField] bool _isActiveWater;
    [SerializeField] int _waterNumber;

    [Header("Axe")]
    [SerializeField] float _axePower;
    [SerializeField] float _axeSize;
    [SerializeField] bool _isActiveAxe;
    [SerializeField] int _axeNumber;

    [Header("Thunder")]
    [SerializeField] float _thunderPower;
    [SerializeField] bool _isActiveThunder;
    [SerializeField] int _thunderNumber;
}
