using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapgenerator : MonoBehaviour {
    public enum havesomecolor
    {
        Noisemap,colormap
    }
    public havesomecolor hvescolor;
    public int width;
    public int height;
    public float scale;
    public int shaders;
    [Range(0,1)]
    public float persi;
    public float lacu;
    public int sd;
    public Vector2 oset;
    public Terrtype[] region;

    public bool isupdated;

	public void gennmap()
    {
        float[,] nmap = Noisem.genertnoisemap(width, height,sd, scale,shaders,persi,lacu,oset);
        Color[] save = new Color[width*height];
        for(int ordone = 0; ordone < height;ordone++)
        {
            for (int abscice = 0; abscice < width; abscice++)
            {
                float current = nmap[abscice, ordone];
                for (int i = 0; i < region.Length; i++) 
                {
                    if (current <= region[i].heght)
                    {
                        save[ordone * width + abscice] = region[i].color;
                        break;
                    }
                }
            }
        }
        thedisplay disp = FindObjectOfType<thedisplay>();
        if(hvescolor == havesomecolor.Noisemap)
        {
            disp.buildmap(Txturegene.fromheimap(nmap));
        }
        else if (hvescolor == havesomecolor.colormap)
        {
            disp.buildmap(Txturegene.takefromcmap(save,width,height));
        }
    }

    private void OnValidate()
    {
        if (width < 1)
            width = 1;
        if (height < 1)
            height = 1;
        if (shaders < 0)
            shaders = 0;
    }
}
[System.Serializable]
public struct Terrtype
{
    public string label;
    public float heght;
   
    public Color color;

}
