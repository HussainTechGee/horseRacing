using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : ScriptableObject
{
    public new string name;
    public float cooldowntimer;
    public float activetimer;


    public virtual void Activatefreez(GameObject player) { }
    public virtual void BeginCooldownfreez(GameObject player) { }


    public virtual void Activateboost(GameObject player) { }
    public virtual void BeginCooldownboost(GameObject player) { }

    public virtual void ActivateDestroyer(GameObject player) { }
    public virtual void BeginCooldownDestroyer(GameObject player) { }
}
