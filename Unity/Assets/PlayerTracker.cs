using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(90, target.rotation.y, target.rotation.z);
    }
}