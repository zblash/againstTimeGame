using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class textGerisayim : MonoBehaviour {

    public TextMeshProUGUI acilis;
    public GameObject karakter;
    SpriteRenderer karekterbeden;
    Rigidbody2D karekterYercekimi;
    public sabitzaman sabitzaman;
    public artanzaman artanzaman;
    Animation bkHareket;
    public int zaman;
	void Start () {
        acilis = GetComponent<TextMeshProUGUI>();
        bkHareket = karakter.GetComponent<Animation>();
        karekterbeden = karakter.GetComponent<SpriteRenderer>();
        karekterYercekimi = karakter.GetComponent<Rigidbody2D>();
        Invoke("calistir",4);
        zaman = 400;
	}
    
	void FixedUpdate () {
        
        if (zaman>100)
        {
            zaman--;
            acilis.text = Mathf.RoundToInt(zaman / 100).ToString();
        }
        else if(zaman>0&&zaman<=100)
        {
            zaman--;
            acilis.text = "GO!!!";
        }
        else
        {
            acilis.enabled = false;
            zaman = -1;
            
        }
        
	}
    void calistir()
    {
        sabitzaman.enabled = true;
        artanzaman.enabled = true;
        karekterbeden.enabled = true;
        karekterYercekimi.simulated = true;
        bkHareket.Play("karekterAnimasyon");

    }
}
