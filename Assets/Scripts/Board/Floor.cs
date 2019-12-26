using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [HideInInspector]

    public TilemapRenderer tileMapRenderer;

    public Vector3Int MaxXY;
    public Vector3Int MinXY;
    
    [HideInInspector]
    public Tilemap tilemap;

    public int order{
        get{
            return tileMapRenderer.sortingOrder;
        }
    }
    public int contentOrder;

    void Awake() {
        tileMapRenderer = GetComponent<TilemapRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    public List<Vector3Int> LoadTiles() {
        List<Vector3Int> tiles = new List<Vector3Int>();
        for(int i = MinXY.x;i < MaxXY.x;i++) {
            for(int j = MinXY.y;j < MaxXY.y;j++) {
                Vector3Int currentPos = new Vector3Int(i,j,0);
                if(tilemap.HasTile(currentPos)) {
                    tiles.Add(currentPos);
                }
            }
        }
        return tiles;
    }
}
