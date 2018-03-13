using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    public Transform[] path;
    public float speed;
    public float RotationSpeed;

    private int current;
    private Quaternion _lookRotation;
    private Vector3 _direction;


    void Update()
    {
        if (transform.position != path[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, path[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % path.Length;
            //find the vector pointing from our position to the target
            _direction = (path[current].position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }

    }
}
