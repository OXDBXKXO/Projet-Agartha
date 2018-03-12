using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour {

    private string _gameVersion = ("0.1");
    ClientState status;
    private bool connected = false;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
        status = PhotonNetwork.connectionStateDetailed;
    }

    

	// Update is called once per frame
	void Update () {
    if (PhotonNetwork.connectionStateDetailed != status)
        {
            status = PhotonNetwork.connectionStateDetailed;
            Debug.Log(status);
        }
    if (connected)
        {
            Debug.Log("Room : " + PhotonNetwork.room.Name + ", isMasterClient : " + PhotonNetwork.isMasterClient);
        }

	}

    void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Join failed");
        PhotonNetwork.CreateRoom("room1");
        Debug.Log("Created : room1");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined room : " + PhotonNetwork.room.Name);
        connected = true;
    }
}