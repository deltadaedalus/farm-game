using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public TileSet[] tileSets;

    Tile[,] tileMap;


	// Use this for initialization
	void Start () {
	    
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

    Tile(intVec2 position, int height, TileSet tileSet)
    {
        this.height = height;
        this.position = position;
        this.tileSet = tileSet;
    }

    void setPiece(int down, int rotation)
    {

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