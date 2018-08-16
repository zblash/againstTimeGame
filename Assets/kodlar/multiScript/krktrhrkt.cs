using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class krktrhrkt : MonoBehaviour
{
    public myUpTime artanzamanScript;
    public myTime sabitzamanScript;
    public GameObject klonlanacakObje, ust;
    public static int sinir, animasyonSinir, pointSum;
    public bool pointcontrol, touchcontrol;
    int kontrol, sabitz, tolerans, kups, point;
    Animation bkHareket;
    Rigidbody2D yercekimi;
    public TextMeshProUGUI puanT;
    SpriteRenderer kDegisim;
    void Start()
    {
       
        bkHareket = transform.parent.gameObject.GetComponent<Animation>();
        point = 4;
        pointcontrol = true;

    }



    private void Update()
    {

        transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, 10 - sinir);
        if (animasyonSinir == 0)
        {
            animasyon();
        }

        if (Input.GetKeyDown(KeyCode.A) )
        {
            cubeO();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        gostergebar.gelendeger = transform.parent.position.y + transform.parent.transform.localScale.y * 3.5f;
        if (sinir < 6)
        {
            if (pointcontrol)
            {
                if (pointSum > 0)
                {
                    pointSum -= point;
                    if (pointSum < 0)
                        pointSum = 0;
                }
                pointTu();
                kups++;
            }
            timeRestart();
            spawn();
            sinir++;
            pointTu();
            
        }
        else if (sinir == 6)
        {
            if (PlayerPrefs.GetInt("highScore", 0) < pointSum)
            {
                PlayerPrefs.SetInt("highScore", pointSum);
            }

            gostergebar.gelendeger = transform.parent.position.y + transform.parent.transform.localScale.y * 3.5f;
            gameObject.GetComponent<krktrhrkt>().enabled = false;
            sinir = 0;
            Time.timeScale = 0f;
        }

    }
    void spawn()
    {
        animasyonSinir = 0;
        GameObject newbob = Instantiate(klonlanacakObje) as GameObject;
        gameObject.name = "olen";
        newbob.transform.position = new Vector2(0, 4.15f);
        if (gameObject.name == "olen")
        {
            gameObject.GetComponent<krktrhrkt>().enabled = false;
        }
        kups = 0;

    }
    void timeRestart()
    {
        sabitzamanScript.enabled = false;
        sayiyaSure();
        artanzamanScript.suresifirla();
        artanzamanScript.enabled = true;

    }
    bool timeEqual(int tolerans)
    {

        kontrol = (artanzamanScript.saniye * 99) + artanzamanScript.salise;
        sabitz = sabitzamanScript.x;
        return ((kontrol >= sabitz - tolerans) && (kontrol <= sabitz + tolerans));
    }
    void animasyon()
    {
        bkHareket.Play("karekterAnimasyon");
        animasyonSinir++;

    }
    void sayiyaSure()
    {
        if (sinir > 0 && sinir < 3)
        {
            sabitzamanScript.sureOlustur(120, 195);
        }
        else if (sinir == 3)
        {
            sabitzamanScript.sureOlustur(100, 165);
        }
        else if (sinir > 3)
        {
            sabitzamanScript.sureOlustur(30, 70);
        }
    }
    void pointTu()
    {
        if (pointSum < 10)
        { puanT.text = "0" + pointSum; }
        else
        { puanT.text = pointSum.ToString(); }

    }
    void cubeO()
    {
        artanzamanScript.enabled = false;
        if (kups == 0)
        {
            if (timeEqual(100))
            {
                pointSum += point;
                pointTu();
                kups++;
                pointcontrol = false;
            }
            else
            {
                pointcontrol = true;

            }
        }

    }


}

