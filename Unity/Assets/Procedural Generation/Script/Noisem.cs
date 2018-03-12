using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noisem  {

    public static float[,] genertnoisemap(int width, int height, float divider, int shaders, float persi, float lacu) {
        float[,] nmap = new float[width, height];
        if (divider <= 0)
            divider = (float)0.0000001;
        float mnh = float.MinValue;
        float minnh = float.MaxValue;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float ampli = 1;
                float frequen = 1;
                float nheigth = 0;

                for (int i = 0; i < shaders; i++)
                {
                    float noix = x / divider * frequen;
                    float noiy = y / divider * frequen;
                    float val = Mathf.PerlinNoise(noix, noiy) * 2 - 1;
                    nheigth = val * ampli;
                    ampli = ampli * frequen;
                    frequen = frequen * lacu;
                }
                if (nheigth > mnh)
                { mnh = nheigth; }
                else if (nheigth < minnh)
                { minnh = nheigth; }
                nmap[x, y] = nheigth;
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                nmap[x, y] = Mathf.InverseLerp(minnh, mnh, nmap[x, y]);
            }
        }
                return nmap;
    }
    
      
    
}
