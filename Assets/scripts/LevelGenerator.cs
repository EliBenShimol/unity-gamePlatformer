using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMapping;
    void Start()
    {
        generateMap();
    }

    public void generateMap()
    {
        for(int x=0;x<map.width;x++)
            for(int y = 0; y <map.height; y++)
            {
                generateTile(x, y);
            }
    }

    private void generateTile(int x, int y)
    {
        Color color=map.GetPixel(x, y);
        if (color.a != 0)
        {
            foreach (ColorToPrefab c in colorMapping){
                if (c.color.Equals(color))
                {
                    Vector2 pos = new Vector2(x, y);
                    if (c.prefab.name.Contains("player"))
                    {
                        GameObject play= Instantiate(c.prefab, pos, Quaternion.identity, transform);
                        scriptFollow.target = play.transform;
                        gunScript.getPlayer(play);
                        GameManegment.player = play;
                        playerBulletScript.player = play;

                    }
                    else
                    {
                        Instantiate(c.prefab, pos, Quaternion.identity, transform);
                    }
                    

                }
            }
        }
    }

}
