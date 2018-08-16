using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class myUpTime : MonoBehaviour {
    public TextMeshProUGUI artan,opponenttext;
    public int salise, saniye,ssalise,ssaniye; 
    void Start()
    {
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
        artan.text = "Your Time 0" + saniye + ":" + salise.ToString("D2");
    }
    public void suresifirla()
    {
        opponenttext.text = "Opponent Time 0"+ssaniye+":"+ ssalise.ToString("D2");
        salise = 0;
        saniye = 0;
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(salise);
            stream.SendNext(saniye);
        }
        else
        {
            this.ssalise = (int)stream.ReceiveNext();
            this.ssaniye = (int)stream.ReceiveNext();
        }
    }
}

