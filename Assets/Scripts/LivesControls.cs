using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesControls : MonoBehaviour
{
    [SerializeField] private IntVariables _livesCount;
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
        _counterTxt.text = ($"{_livesCount.value}");
    }

    // Update is called once per frame
    void Update()
    {
        if (_livesCount.value != _changeTracker)
        {
            _counterTxt.text = ($"{_livesCount.value}");
            _changeTracker = _livesCount.value;
        }


    }
}
