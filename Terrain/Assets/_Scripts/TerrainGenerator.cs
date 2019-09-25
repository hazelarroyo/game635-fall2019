using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    Terrain terrain;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        float[,] heightmap = terrain.terrainData.GetHeights(0,0,terrain.terrainData.heightmapWidth, 
            terrain.terrainData.heightmapWidth);

        for (int i=0; i<terrain.terrainData.heightmapHeight; i++)
        {
            for (int j=0; j<terrain.terrainData.heightmapWidth; j++)
            {
                float x = j / (float) terrain.terrainData.heightmapWidth;
                float y = i / (float) terrain.terrainData.heightmapHeight;
                heightmap[i, j] = Mathf.PerlinNoise(x, y);
            }
        }

        terrain.terrainData.SetHeights(0, 0, heightmap);
    }

    void Update()
    {
        
    }
}
