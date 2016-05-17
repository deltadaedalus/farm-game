using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public TileSet[] tileSets;
    public Texture2D mapTex;
    public Texture2D heightTex;

    Tile[,] tileMap;
    int width;
    int height;

	// Use this for initialization
	void Start () {
	    width = mapTex.width;
        height = mapTex.height;
        Debug.Log(width);
        Debug.Log(height);
        tileMap = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tileMap[x, y] = new Tile(new intVec2(x, y), (int)(heightTex.GetPixel(x, y).r * 32), tileSets[0]);
                tileMap[x, y].setPiece(0, 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}

public class Tile
{
    GameObject piece;
    TileSet tileSet;
    intVec2 position;
    int height;

    public Tile(intVec2 position, int height, TileSet tileSet)
    {
        this.height = height;
        this.position = position;
        this.tileSet = tileSet;
    }

    public void setPiece(int down, int rotation)
    {
        piece = (GameObject)Object.Instantiate(tileSet.flatPrefab, new Vector3((float)position.x, height * 0.5f, (float)position.y), Quaternion.identity);
    }
}

public class intVec2
{
    public int x;
    public int y;

    public intVec2(int x, int y){
        this.x = x;
        this.y = y;
    }
}