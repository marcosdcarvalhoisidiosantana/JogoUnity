using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
   public override void Enter() {
       StartCoroutine(loadSequence());

   }
   IEnumerator loadSequence() {
       yield return StartCoroutine(Board.instance.InitSequence(this));

       yield return null;
       SMController.instance.ChangeTo<RoamState>();
   }
}
