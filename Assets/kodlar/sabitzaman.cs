using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class sabitzaman : MonoBehaviour {
    public TextMeshProUGUI sabit;
   public int sabitsaniye, sabitsalise,x;

    void Start () {

        sureOlustur();
        
	}
    public void sureOlustur()
    {
        x = UnityEngine.Random.Range(200,225);
        sureYazdir();
        
    }
    public void sureYazdir()
    {
        sabitsaniye = x / 100;
        sabitsalise = x % 100;
        sabit.text = "0" + sabitsaniye + ":" + sabitsalise.ToString("D2");
    }
	
    
}
