using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroOnCell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private TextMeshPro _hpText;
    [SerializeField]private TextMeshPro _attackText;
    private int hpValue=10;
    private int attackValue=1;
    void Start()
    {
        _hpText.text = hpValue.ToString();
        _attackText.text = attackValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateHero()
    {
        
    }
}
