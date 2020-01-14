using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server...");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print( "Now connected to " + PhotonNetwork.CloudRegion + " server!" );
        print( "Player Nickname: " + PhotonNetwork.LocalPlayer.NickName );
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print( "Disconnected from server reason: " + cause.ToString() );
    }
}
