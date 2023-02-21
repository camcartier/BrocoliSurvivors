using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootControls : MonoBehaviour
{
    [SerializeField] IntVariables _expCount;
    [SerializeField] LootData _lootData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "GreenGem")
        {
            Debug.Log("touched");
            _expCount.value += _lootData._greenGemGivenExpValue;
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && gameObject.tag == "BlueGem")
        {
            _expCount.value += _lootData._blueGemGivenExpValue;
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && gameObject.tag == "RedGem")
        {
            _expCount.value += _lootData._redGemGivenExpValue;
            Destroy(this.gameObject);
        }

    }

}
