using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        

        

        Actions actions = GetComponent<Actions>();


        float y = 0;


        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            actions.Stay();
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                actions.Run();
                y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
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
