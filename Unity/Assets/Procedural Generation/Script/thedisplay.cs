using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thedisplay : MonoBehaviour {

    public Renderer txture;
    public void buildnmap(float[,] nmap)
    {
        int width = nmap.GetLength(0);
        int height = nmap.GetLength(1);
        Texture2D texture = new Texture2D(width, height);
        Color[] colorm = new Color[width * height];
        for(int y = 0;y < height;y++)
        {
            for(int x = 0;x < width;x++)
            {
                colorm[y * width + x] = Color.Lerp(Color.black, Color.white, nmap[x, y]);
            }
        }
        texture.SetPixels(colorm);
        texture.Apply();
        txture.sharedMaterial.mainTexture = texture;
        txture.transform.localScale = new Vector3(width, 1, height);

    }
}
