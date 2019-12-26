using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{
    public Vector3Int pos;

    public Vector3 worldPos;

    public GameObject content;

    public Floor floor;

    public int contentOrder;

    public TileLogic() {

    }

    public TileLogic(Vector3Int pos,Vector3 worldPos,Floor floor) {
        this.pos = pos;
        this.worldPos = worldPos;
        this.floor = floor;
        contentOrder = floor.contentOrder;
        
    }
        

}
