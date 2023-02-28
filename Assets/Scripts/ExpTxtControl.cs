using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpTxtControl : MonoBehaviour
{
    [SerializeField] private IntVariables _expCount;
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
        _expTxt.text = ($"{_expCount.value}");
    }

    // Update is called once per frame
    void Update()
    {
        if (_expCount.value != _changeTracker)
        {
            _expTxt.text = ($"{_expCount.value}");
            _changeTracker = _expCount.value;
        }


    }
}