using System;
using System.Collections;
using Photon;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

using ExitGames.Client.Photon;

// the Photon server assigns a ActorNumber (player.ID) to each player, beginning at 1
// for this game, we don't mind the actual number
// this game uses player 0 and 1, so clients need to figure out their number somehow
public class RpsCore : PunBehaviour
{

    [SerializeField]
    private Text TurnText;

   
    private ResultType result;

    private string s;
    private bool t = true;

    private PunTurnManager turnManager;

    public myTime mytime;
    public Hand randomHand;    // used to show remote player's "hand" while local player didn't select anything

	// keep track of when we show the results to handle game logic.
	private bool IsShowingResults;
	
    public enum Hand
    {
        None = 0,
        Rock,
        Paper,
        Scissors
    }

    public enum ResultType
    {
        None = 0,
        Draw,
        LocalWin,
        LocalLoss
    }

    public void Start()
    {
		this.turnManager = this.gameObject.AddComponent<PunTurnManager>();
        this.turnManager.TurnDuration = 5f;
 
        
    }

    public void FixedUpdate()
    {


        // for debugging, it's useful to have a few actions tied to keys:
        if (Input.GetKeyUp(KeyCode.L))
        {
            PhotonNetwork.LeaveRoom();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            PhotonNetwork.ConnectUsingSettings(null);
            PhotonHandler.StopFallbackSendAckThread();
        }


        if (!PhotonNetwork.inRoom)
        {
            return;
        }
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            if (t)
            {
                mytime.sureOlustur(1,2);
                Debug.Log(mytime.x);
            }
            t = false;
        }



        if (PhotonNetwork.room.PlayerCount > 1)
        {
            if (this.turnManager.IsOver)
            {
                return;
            }

            /*
			// check if we ran out of time, in which case we loose
			if (turnEnd<0f && !IsShowingResults)
			{
					Debug.Log("Calling OnTurnCompleted with turnEnd ="+turnEnd);
					OnTurnCompleted(-1);
					return;
			}
		*/


        }
    }



    [PunRPC]
    void UniCreate(string ss)
    {

        TurnText.text = ss;
    }


}

  

