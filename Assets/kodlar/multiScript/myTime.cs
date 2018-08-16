using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class myTime : MonoBehaviour
{
   
    public TextMeshProUGUI sabit;
    public int sabitsaniye, sabitsalise, x,sprite;
    PhotonView _photonView;
    public SpriteRenderer kDegisim;
    void Start(){
        _photonView = this.GetComponent<PhotonView>();
        sureOlustur(200,225);
                }   
    public void sureOlustur(int first,int second)
    {
            if (PhotonNetwork.isMasterClient)
            {
            x = UnityEngine.Random.Range(first, second);
            _photonView.RPC("sureYazdir", PhotonTargets.All, x);
            }
            
        
    }

    [PunRPC]
    public void sureYazdir(int xx)
    {

        sabitsaniye = xx / 100;
        sabitsalise = xx % 100;
        sabit.text = "Turn Time 0" + sabitsaniye + ":" + sabitsalise.ToString("D2");
    }




}
