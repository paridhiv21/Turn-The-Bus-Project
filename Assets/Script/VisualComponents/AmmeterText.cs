using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmeterText : MonoBehaviour
{
    [SerializeField] TextMeshPro AmmeterValue;

    public void UpdateAmmeterValue(double ammeterValue)
    {
        if(ammeterValue >= 1000 || ammeterValue <= -1000) { AmmeterValue.text = string.Format("{0:0.##}", ammeterValue / 1000) + " A"; }
        else { AmmeterValue.text = string.Format("{0:0.##}", ammeterValue) + " mA"; }
    }

    public void InitAmmeterValue()
    {
        AmmeterValue = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
