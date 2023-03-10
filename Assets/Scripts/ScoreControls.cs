using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreControls : MonoBehaviour
{
    [SerializeField] private IntVariables _killCount;
    private TMP_Text _counterTxt;
    private int _changeTracker;


    // Start is called before the first frame update
    private void Awake()
    {
        _counterTxt = GetComponent<TMP_Text>();
        _changeTracker = 0;
    }

    void Start()
    {
        _counterTxt.text = ($"{_killCount.value}");
    }

    // Update is called once per frame
    void Update()
    {
        if (_killCount.value != _changeTracker)
        {
            _counterTxt.text = ($"{_killCount.value}");
            _changeTracker = _killCount.value;
        }


    }
}


