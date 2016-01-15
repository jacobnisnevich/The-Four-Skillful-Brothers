using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {
    public enum Terrain
    {
        Grass,
        Dirt,
        Tree
    }

    public int x;
    public int y;
    public Terrain terrain;
    public bool selected; 

    public Color grassColor     = new Color(0.18f, 0.49f, 0.20f);
    public Color dirtColor      = new Color(0.47f, 0.33f, 0.28f);
    public Color treeColor      = new Color(0.11f, 0.37f, 0.13f);
    public Color selectionColor = new Color(0.95f, 0.90f, 0.10f, 0.5f);

	// Use this for initialization
	void Start () {
        selected = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            unSelectTiles();

            selected = true;
            gameObject.GetComponent<Renderer>().material.color = selectionColor;
        }
    }

    void unSelectTiles()
    {
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in allTiles)
        {
            tile.GetComponent<TileController>().selected = false;
            tile.GetComponent<TileController>().resetColor();
        }
    }

    void resetColor()
    {
        switch (terrain)
        {
            case Terrain.Grass:
                gameObject.GetComponent<Renderer>().material.color = grassColor;
                break;
            case Terrain.Dirt:
                gameObject.GetComponent<Renderer>().material.color = dirtColor;
                break;
            case Terrain.Tree:
                gameObject.GetComponent<Renderer>().material.color = treeColor;
                break;
        }
    }
}
