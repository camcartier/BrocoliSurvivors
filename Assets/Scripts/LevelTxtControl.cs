using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTxtControl : MonoBehaviour
{
    [SerializeField] private IntVariables _levelTracker;
    private TMP_Text _expTxt;
    private int _changeTracker;


    // Start is called before the first frame update
    private void Awake()
    {
        _expTxt = GetComponent<TMP_Text>();
        _changeTracker = 0;
    }

    void Start()
    {
        _expTxt.text = ("Lvl " +_levelTracker.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelTracker.value != _changeTracker)
        {
            _expTxt.text = ("Lvl " + _levelTracker.value);
            _changeTracker = _levelTracker.value;
        }
    }
}