using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class artanzaman : MonoBehaviour {
    public TextMeshProUGUI artan;
    public int salise,saniye;
	void Start () {
        salise = 0;
        saniye = 0;
	}

    void FixedUpdate()
    {

        surearttır();
        

    }
    public void surearttır()
    {
        salise++;
        if (salise == 99)
        {
            saniye++;
            salise = 0;
        }
        artan.text = "0" + saniye + ":" + salise.ToString("D2");
    }
    public void suresifirla()
    {
        salise = 0;
        saniye = 0;
    }
}
