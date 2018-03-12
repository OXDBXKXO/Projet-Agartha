using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noisem  {

    public static float[,] genertnoisemap(int width, int height, int sd,float divider, int shaders, float persi, float lacu,Vector2 oset) {
        float[,] nmap = new float[width, height];
        System.Random proceduralbng = new System.Random(sd);
        Vector2[] shdrs = new Vector2[shaders];
        for(int j = 0; j < shaders;j++)
        {
            float ostx = proceduralbng.Next(-10000, 10000) +  oset.x;
            float osty = proceduralbng.Next(-10000, 10000) + oset.y;
            shdrs[j] = new Vector2(ostx, osty);

        }

        if (divider <= 0)
            divider = (float)0.0000001;
        float mnh = float.MinValue;
        float minnh = float.MaxValue;
        float hwi = (float)width / 2;
        float hhei = (float)height / 2;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float ampli = 1;
                float frequen = 1;
                float nheigth = 0;

                for (int i = 0; i < shaders; i++)
                {
                    float noix = (x - hwi)/ divider * frequen + shdrs[i].x;
                    float noiy = (y- hhei) / divider * frequen + shdrs[i].y;
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
