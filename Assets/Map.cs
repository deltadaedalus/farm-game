using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public GameObject flatPrefab;
    public GameObject slopePrefab;
    public GameObject outPrefab;
    public GameObject inPrefab;

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
    Tile(intVec2 position, int height)
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