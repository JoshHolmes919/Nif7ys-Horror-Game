using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()//on start
    {
        print("Connecting to server...");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print( "Your chosen region is " + PhotonNetwork.CloudRegion + "!" );
        print( "Game version is set to " + PhotonNetwork.GameVersion );
        print( "Player nickname chosen: " + PhotonNetwork.LocalPlayer.NickName );
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print( "Disconnected from server reason: " + cause.ToString() );
    }
}
