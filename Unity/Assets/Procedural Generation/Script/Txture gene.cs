using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txturegene 
{
    public static Texture2D takefromcmap(Color[] colormap,int width,int height)
    {
        Texture2D txt = new Texture2D(width, height);
        txt.SetPixels(colormap);
        txt.Apply();
        return txt;
    }
    public static Texture2D fromheimap(float[,] heimap)
    {
        int width = heimap.GetLength(0);
        int height = heimap.GetLength(1);
        
        Color[] colorm = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorm[y * width + x] = Color.Lerp(Color.black, Color.white, heimap[x, y]);
            }
        }
          return takefromcmap(colorm,width,height);
    }
	
}
