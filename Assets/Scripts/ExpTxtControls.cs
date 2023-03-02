using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpTxtControls : MonoBehaviour
{
    private int _expToReachTracker;
    [SerializeField] private IntVariables _currentExp;
    private TMP_Text _expTxt;
    private int _currentExpTracker;
    private int _changeToReachTracker;


    // Start is called before the first frame update
    private void Awake()
    {
        _expTxt = GetComponent<TMP_Text>();
        _expToReachTracker = GameObject.Find("GameManager").GetComponent<GameManager>()._expForNextLevel;
        _currentExpTracker = 0;
        _changeToReachTracker = 0;
    }

    void Start()
    {
        _expTxt.text = (_currentExp.value + "/" + _expToReachTracker);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_expToReachTracker);
        /*if (_expToReachTracker != _changeToReachTracker)
        {
            _expTxt.text = (_currentExp.value + "/" + _expToReachTracker);
            _changeToReachTracker = _expToReachTracker;
        }*/
        if(_currentExp.value != _currentExpTracker)
        {
            _expTxt.text = (_currentExp.value + "/" + _expToReachTracker);
            _changeToReachTracker = _expToReachTracker;
        }
    }
}