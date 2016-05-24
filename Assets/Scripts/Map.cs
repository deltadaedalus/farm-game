using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
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
            for (int y = 0; y < height; y++)
                tileMap[x, y] = new Tile(new intVec2(x, y), (int)(heightTex.GetPixel(x, y).r * 32), tileSets[0]);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int pp = System.Math.Max(System.Math.Max(getTile(x + 1, y + 1).height, getTile(x, y + 1).height), getTile(x + 1, y).height);
                int pn = System.Math.Max(System.Math.Max(getTile(x + 1, y - 1).height, getTile(x, y - 1).height), getTile(x + 1, y).height);
                int np = System.Math.Max(System.Math.Max(getTile(x - 1, y + 1).height, getTile(x, y + 1).height), getTile(x - 1, y).height);
                int nn = System.Math.Max(System.Math.Max(getTile(x - 1, y - 1).height, getTile(x, y - 1).height), getTile(x - 1, y).height);
                tileMap[x, y].setPiece(pp, pn, np, nn);
            }
                
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    Tile getTile(int x, int y) {
        x = Util.mod(x, width);
        y = Util.mod(y, height);

        return tileMap[x, y];
    }

    float getHeight()
    {
        return 0.0f;
    }
}

public class Tile
{
    GameObject piece;
    TileSet tileSet;
    intVec2 position;
    public int height;

    public Tile(intVec2 position, int height, TileSet tileSet)
    {
        this.height = height;
        this.position = position;
        this.tileSet = tileSet;
    }

    public void setPiece(int pp, int pn, int np, int nn)
    {
        int pieceNum = 0;
        Vector3 pos = new Vector3((float)position.x, height * 0.5f, (float)position.y);

        if (pp - height == 1) pieceNum += 1;
        if (pn - height == 1) pieceNum += 2;
        if (np - height == 1) pieceNum += 4;
        if (nn - height == 1) pieceNum += 8;

        //This could potentially be prettier, but 16 is a small number so fuck it
        switch(pieceNum) {
            case 0: piece = (GameObject)Object.Instantiate(tileSet.flatPrefab, pos, tileSet.flatPrefab.transform.rotation); break;
            case 1: piece = (GameObject)Object.Instantiate(tileSet.outPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(180, Vector3.forward)); break;
            case 2: piece = (GameObject)Object.Instantiate(tileSet.outPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(270, Vector3.forward)); break;
            case 3: piece = (GameObject)Object.Instantiate(tileSet.slopePrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(270, Vector3.forward)); break;
            case 4: piece = (GameObject)Object.Instantiate(tileSet.outPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(90, Vector3.forward)); break;
            case 5: piece = (GameObject)Object.Instantiate(tileSet.slopePrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(180, Vector3.forward)); break;

            case 7: piece = (GameObject)Object.Instantiate(tileSet.inPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(180, Vector3.forward)); break;
            case 8: piece = (GameObject)Object.Instantiate(tileSet.outPrefab, pos, tileSet.flatPrefab.transform.rotation); break;

            case 10: piece = (GameObject)Object.Instantiate(tileSet.slopePrefab, pos, tileSet.flatPrefab.transform.rotation); break;
            case 11: piece = (GameObject)Object.Instantiate(tileSet.inPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(270, Vector3.forward)); break;
            case 12: piece = (GameObject)Object.Instantiate(tileSet.slopePrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(90, Vector3.forward)); break;
            case 13: piece = (GameObject)Object.Instantiate(tileSet.inPrefab, pos, tileSet.flatPrefab.transform.rotation * Quaternion.AngleAxis(90, Vector3.forward)); break;
            case 14: piece = (GameObject)Object.Instantiate(tileSet.inPrefab, pos, tileSet.flatPrefab.transform.rotation); break;

            default: piece = (GameObject)Object.Instantiate(tileSet.flatPrefab, pos, tileSet.flatPrefab.transform.rotation); break;
        }
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