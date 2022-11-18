using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class freezAbility : Skills
{
    public override void Activatefreez(GameObject player)
    {
        player.GetComponent<PlayerScript>().freezOthers = true;
    }

    public override void BeginCooldownfreez(GameObject player)
    {
        player.GetComponent<PlayerScript>().freezOthers = false;
    }
}
