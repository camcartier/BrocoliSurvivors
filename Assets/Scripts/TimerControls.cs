using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerControls : MonoBehaviour
{
    [SerializeField] FloatVariables _timerValue;
    private TMP_Text _timerTxt;
    private float _changeTracker;

    private void Awake()
    {
        _timerTxt = GetComponent<TMP_Text>();
        _changeTracker = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _timerTxt.text = ($"{_timerValue.value}");
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerValue.value != _changeTracker)
        {
            _timerTxt.text = ($"{_timerValue.value}");
            _changeTracker = _timerValue.value;
        }
    }
}
