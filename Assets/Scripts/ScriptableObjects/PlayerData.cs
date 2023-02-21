using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header ("Passives")]
    public int _maxHealth;
    public float _healthRecovery;
    public int _moveSpeed;
    public int _armor;
    [Header ("AttackStats")]
    public int _attPower;
    public float _attackSpeed;
    public float _attackSize;
    public float _fireRate;
    [Header("OtherStats")]
    public int _maxLives;
    public int _curseAmount;

}
