using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseActionState : State
{
    public override void Enter(){
        base.Enter();
        InputController.instance.onMove+=onMove; 
    }
    public override void Exit() {
        base.Exit();
        InputController.instance.onMove-=onMove; 
    }

    void onMove(object sender, object args) {
    }
}
