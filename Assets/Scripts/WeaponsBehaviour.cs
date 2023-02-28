using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponsBehaviour : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] WeaponData _weaponData;
    [Header("Garlic")]
    [SerializeField] GameObject _garlicFX;
    public bool _activateGarlic;
    [Header("HolyWater")]
    [SerializeField] GameObject _waterFx;
    public bool _activateWater;
    private float _waterTimer =2f;
    private float _waterTimerCounter;
    [Header("Axe")]
    [SerializeField] GameObject _axeFX;
    [Header("Thunder")]
    [SerializeField] GameObject _thunderFX;
    List<GameObject> livingEnemies = new List<GameObject>();


    public UnityEvent Upgrade;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    // Start is called before the first frame update

    public void ButtonAxe()
    {
        Upgrade.AddListener(Axe);
    }

    public void ButtonWater()
    {
        Upgrade.AddListener(HolyWater);
    }

    public void ButtonThunder()
    {
        Upgrade.AddListener(Thunder);
    }

    public void Garlic()
    {
        Instantiate(_garlicFX, _player.transform.position, Quaternion.identity);
    }

    public void HolyWater()
    {
        Debug.Log("water");
        List<GameObject> collectedwaters = new List<GameObject>();
        for (int i = 0; i<_weaponData._waterNumber; i++)
        {
            Instantiate(_waterFx, new Vector2(Random.Range((_player.transform.position.x - 10f), (_player.transform.position.x + 10f)), Random.Range((_player.transform.position.y + 10), (_player.transform.position.y - 10))), Quaternion.identity);
            collectedwaters.Add(_waterFx);
            //Debug.Log($"{collectedwaters.Count}");
        }

        //ne marchera que si mis dans un update
        if (_waterTimerCounter < _waterTimer)
        {
            _waterTimerCounter += Time.deltaTime;
            Debug.Log($"{_waterTimerCounter}");
        }
        else
        {
            for (int i = 0; i < collectedwaters.Count; i++)
            {
                Destroy(collectedwaters[i].gameObject);
            }
        }
    }

    public void Axe()
    {
        for (int i = 0; i < _weaponData._axeNumber; i++)
        {
            Instantiate(_axeFX, _player.transform.position, Quaternion.identity);
        }
    }

    public void Thunder()
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            livingEnemies.Add(enemy);
        }
        for (int i = 0; i < _weaponData._thunderNumber; i++)
        {
            Instantiate(_thunderFX, livingEnemies[Random.Range(0, livingEnemies.Count - 1)].transform.position, Quaternion.identity);
        }
    }
}
