using UnityEngine;
using System;
using System.IO;
using System.Collections;
using SimpleJSON;

public class GenerateTiles : MonoBehaviour {
    public float tileSize = 3.0f;
    private float tileHeight = 0.251f;

    private Quaternion levelAngle = Quaternion.Euler(new Vector3(90f, 0f, 0f));
    private Vector3 tileScale = new Vector3(3f, 3f, 1f);

    private Color grassColor = new Color(0.18f, 0.49f, 0.20f);
    private Color dirtColor  = new Color(0.47f, 0.33f, 0.28f);
    private Color treeColor  = new Color(0.11f, 0.37f, 0.13f);

	// Use this for initialization
	void Start () {
        using (StreamReader sr = new StreamReader("Assets/MapData.json"))
        {
            String mapDataString = sr.ReadToEnd();
            var mapData = JSON.Parse(mapDataString);

            float width  = mapData["width"].AsFloat;
            float height = mapData["height"].AsFloat;
            var tileMap  = mapData["tiles"].AsArray;

            float startTileX = 0 - (width  * tileSize) / 2 + tileSize / 2;
            float startTileZ =     (height * tileSize) / 2 - tileSize / 2;
            float tileX = startTileX;
            float tileZ = startTileZ;

            for (int y = 0; y < tileMap.Count; y++)
            {
                for (int x = 0; x < tileMap[y].Count; x++)
                {
                    GameObject currentTile = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    currentTile.transform.position = new Vector3(tileX, tileHeight, tileZ);
                    currentTile.transform.rotation = levelAngle;
                    currentTile.transform.localScale = tileScale;
                    currentTile.transform.parent = gameObject.transform.FindChild("Tiles").transform;
                    currentTile.transform.name = "tile-" + x + "-" + y;
                    currentTile.tag = "Tile";

                    currentTile.AddComponent<TileController>();
                    TileController currentTileController = currentTile.GetComponent<TileController>();
                    currentTileController.x = x;
                    currentTileController.y = x;

                    switch (tileMap[y][x].Value)
                    {
                        case "g":
                            currentTile.GetComponent<Renderer>().material.color = grassColor;
                            currentTileController.terrain = TileController.Terrain.Grass;
                            break;
                        case "d":
                            currentTile.GetComponent<Renderer>().material.color = dirtColor;
                            currentTileController.terrain = TileController.Terrain.Dirt;
                            break;
                        case "t":
                            currentTile.GetComponent<Renderer>().material.color = treeColor;
                            currentTileController.terrain = TileController.Terrain.Tree;
                            break;
                    }

                    tileX += tileSize;
                }

                tileZ -= tileSize;
                tileX = startTileX;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
