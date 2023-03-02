using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private IntVariables _currentExp;
    private int _expToNextLevel = 5;

    private void Awake()
    {
        _expToNextLevel = GameObject.Find("GameManager").GetComponent<GameManager>()._expForNextLevel;
    }

    public void SetMaxExp(int value)
    {
        slider.maxValue = value;
        slider.value = 0;
    }
    public void SetExp()
    {
        slider.value = _currentExp.value;
        Debug.Log("slider set");
    }
}
