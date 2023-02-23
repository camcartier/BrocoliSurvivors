using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    [Header("Garlic")]
    public int _garlicPower;
    public float _garlicSize;
    public bool _isActiveGarlic;

    [Header("BlessedWater")]
    public int _waterPower;
    public float _waterSize;
    public float _waterDuration;
    public bool _isActiveWater;
    public int _waterNumber;

    [Header("Axe")]
    public int _axePower;
    public float _axeSize;
    public bool _isActiveAxe;
    public int _axeNumber;

    [Header("Thunder")]
    public int _thunderPower;
    public bool _isActiveThunder;
    public int _thunderNumber;
}
