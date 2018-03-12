using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPole : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameManager.instance.Win();
    }
}
