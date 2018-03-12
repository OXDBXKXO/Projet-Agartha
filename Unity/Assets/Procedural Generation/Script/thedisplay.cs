using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thedisplay : MonoBehaviour {

    public Renderer txture;
    public void buildmap(Texture2D txt)
    {
       
        txture.sharedMaterial.mainTexture = txt;
        txture.transform.localScale = new Vector3(txt.width, 1, txt.height);

    }
}
