using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootControls : MonoBehaviour
{
    [SerializeField] IntVariables _expCount;
    [SerializeField] LootData _lootData;
    private ExpSlider _expSlider;

    private ParticleSystem _expUpFX;

    private void Awake()
    {
        _expSlider = GameObject.Find("Slider").GetComponent<ExpSlider>();
        _expUpFX = GameObject.Find("expUpFX").GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "GreenGem")
        {
            _expCount.value += _lootData._greenGemGivenExpValue;
            _expSlider.SetExp();
            _expUpFX.Play();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && gameObject.tag == "BlueGem")
        {
            _expCount.value += _lootData._blueGemGivenExpValue;
            _expSlider.SetExp();
            _expUpFX.Play();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && gameObject.tag == "RedGem")
        {
            _expCount.value += _lootData._redGemGivenExpValue;
            _expSlider.SetExp();
            _expUpFX.Play();
            Destroy(this.gameObject);
        }

    }

}
