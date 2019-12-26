using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter(){
        base.Enter();
        InputController.instance.onMove+=onMove; 
        CheckNullPosition();
    }

    public override void Exit() {
        base.Exit();
        InputController.instance.onMove-=onMove; 
    }

    void onMove(object sender, object args) {
        Vector3Int input = (Vector3Int)args;
        TileLogic t = Board.instance.GetTile(Selector.instance.position + input);

        if(t != null) {
            Selector.instance.position = t.pos;
            Selector.instance.tile = t;
            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
            Selector.instance.transform.position = t.worldPos;
        }
    }

    void CheckNullPosition() {
        if(Selector.instance.position == null) {
            TileLogic t = Board.instance.GetTile(new Vector3Int(-7,-1,0));
            Selector.instance.position = t.pos;
            Selector.instance.tile = t;
            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
            Selector.instance.transform.position = t.worldPos;
        }
    }
}
