using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapgenerator : MonoBehaviour {
    public int width;
    public int height;
    public float scale;

	public void gennmap()
    {
        float[,] nmap = Noisem.genertnoisemap(width, height, scale);
        thedisplay disp = FindObjectOfType<thedisplay>();
        disp.buildnmap(nmap);
    }
}
