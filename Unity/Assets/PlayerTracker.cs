using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

    PhotonView phoview;
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        phoview = GetComponent<PhotonView>();
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (phoview.isMine)
        {
            transform.position = player.transform.position + offset;
            transform.rotation = player.transform.rotation;
        }
    }
}
