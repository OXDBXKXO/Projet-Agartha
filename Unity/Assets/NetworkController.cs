using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NetworkController : MonoBehaviour {

    public string Version;
    public bool AutoConnect = true;
    public GameObject PlayerPrefab;
    public GameObject CamPrefab;

    private Text status;
    private Text isMaster;

    // Use this for initialization
    void Start () {
        PhotonNetwork.autoJoinLobby = false;
        status = GameObject.Find("Status").GetComponent<Text> ();
        isMaster = GameObject.Find("IsMaster").GetComponent<Text>();
    }

    

	// Update is called once per frame
	void Update () {
        if (AutoConnect && !PhotonNetwork.connected)
        {
            status.text = "Status : Update() calling ConnectIssingSettings()";
            AutoConnect = false;
            PhotonNetwork.ConnectUsingSettings(Version);
        }

    }

    public virtual void OnConnectedToMaster()
    {
        status.text = "Status : OnConnectedToMaster() calling PhotonNetwork.JoinRandomRoom()";
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        status.text = "Status : OnJoinedLobby() calling PhotonNetwork.JoinRandomRoom()";
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        status.text = "Status : OnPhotonRandomJoinFailed() calling PhotonNetwork.CreateRoom()";
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        status.text = "Status : OnJoinedRoom(). Connected !";

        isMaster.text = "isMaster : " + PhotonNetwork.isMasterClient;

        //Player is connected, now we need to make him spawn

        PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, Quaternion.identity, 0);
        PhotonNetwork.Instantiate(CamPrefab.name, CamPrefab.transform.position, Quaternion.identity, 0);
    }
}