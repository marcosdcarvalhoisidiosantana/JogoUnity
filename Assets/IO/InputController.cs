using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DelegateModel(object sender, object args);
public class InputController : MonoBehaviour
{
    float hCoolDown = 0;
    float vCoolDown = 0;
    float jCoolDown = 0;
    float wCoolDown = 0;

    float coolDownTimer = 0.5f;

    public static InputController instance;

    public DelegateModel onMove;
    public DelegateModel onFire;

    void Awake() {
        instance = this;
    }
    void Update()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        int j = Mathf.RoundToInt(Input.GetAxisRaw("NESO"));
        int w = Mathf.RoundToInt(Input.GetAxisRaw("NOSE"));
        Vector3Int moved = new Vector3Int(0,0,0);

        if(h != 0) {
            Vector3Int movedaux = new Vector3Int(h,0,0);
            moved = GetMoved(ref hCoolDown,movedaux); 
        } else 
            hCoolDown = 0;
        if(v != 0) {
            Vector3Int movedaux = new Vector3Int(0,v,0);
            moved = GetMoved(ref vCoolDown,movedaux); 
        } else
            vCoolDown = 0;

        if(j != 0) {
            Vector3Int movedaux = new Vector3Int(j,j,0);
            moved = GetMoved(ref jCoolDown,movedaux);
        } else
            jCoolDown = 0;

        if(w != 0) {
            Vector3Int movedaux = new Vector3Int(-w,w,0);
            moved = GetMoved(ref wCoolDown,movedaux);
        } else
            wCoolDown = 0;

        if(moved != Vector3Int.zero && onMove != null) {
            onMove(null,moved);
        }
        
        if(Input.GetButtonDown("Fire1") && onFire != null) {
            onFire(null,1);
        }

        if(Input.GetButtonDown("Fire2") && onFire != null) {
            onFire(null,2);
        }

    }

    Vector3Int GetMoved(ref float CoolDownSum, Vector3Int value) {
        if(Time.time > CoolDownSum) {
            CoolDownSum += Time.time+coolDownTimer;
            return value;
        }
        return new Vector3Int(0,0,0);
    }
}
