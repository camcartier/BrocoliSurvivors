using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStatsManager : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] WeaponData _weaponData;
    //private WeaponsBehaviour _weaponBehaviour;

    public List<System.Action> Effects = new List<System.Action>();

    private void Awake()
    {
        Effects.Add(IncreaseMoveSpeed);
        Effects.Add(IncreaseAttPower);
        Effects.Add(IncreaseArmor);
        Debug.Log(Effects);
    }


    public void GetRandomIncrease()
    {
        int chosenEffect = Random.Range(0, Effects.Count);
        if (chosenEffect == 0) { IncreaseMoveSpeed(); }
        if (chosenEffect == 1) { IncreaseAttPower(); }
        if (chosenEffect == 2) { IncreaseArmor(); }
    }

    public void IncreaseMoveSpeed()
    {
        _playerData._moveSpeed += 50;
        Debug.Log(_playerData._moveSpeed);
    }

    public void IncreaseAttPower()
    {
        _playerData._attPower += 1;
        Debug.Log(_playerData._attPower);
    }

    /*
    public void IncreaseBulletsNumber()
    {

    }*/

    public void IncreaseArmor()
    {
        _playerData._armor += 1;
        Debug.Log(_playerData._armor);
    }
}
