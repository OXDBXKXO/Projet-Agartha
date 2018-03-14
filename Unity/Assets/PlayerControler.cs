using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    PhotonView phoview;
    public GameObject cam;
    public bool Online;

    void Start()
    {
        phoview = GetComponent<PhotonView>();
        if (phoview.isMine || !Online)
            cam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (phoview.isMine || !Online)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 250.0f;


            Actions actions = GetComponent<Actions>();

            float y = 0;

            if (Input.GetKey(KeyCode.Space))
                actions.Death();

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                actions.Stay();
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    actions.Run();
                    y = Input.GetAxis("Vertical") * Time.deltaTime * 6.0f;
                }
                else
                {
                    actions.Walk();
                    y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
                }
            }

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, y);
        }
    }
}
