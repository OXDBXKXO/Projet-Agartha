using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapgenerator : MonoBehaviour {
    public int width;
    public int height;
    public float scale;
    public int shaders;
    public float persi;
    public float lacu;
    public bool isupdated;

	public void gennmap()
    {
        float[,] nmap = Noisem.genertnoisemap(width, height, scale,shaders,persi,lacu);
        thedisplay disp = FindObjectOfType<thedisplay>();
        disp.buildnmap(nmap);
    }
}
