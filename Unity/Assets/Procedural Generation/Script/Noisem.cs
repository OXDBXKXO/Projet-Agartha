using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noisem  {

	public static float[,] genertnoisemap(int width, int height, float divider) {
        float[,] nmap = new float[width , height];
        if (divider <= 0)
            divider = (float)0.0000001;
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                float noix = x/divider;
                float noiy = y/divider;
                float val = Mathf.PerlinNoise(noix, noiy);
                nmap[x, y] = val;

            }
        }
        return nmap;
    }
    
      
    
}
