using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoostAbility : Skills
{
    public override void Activateboost(GameObject player)
    {
        player.GetComponent<PlayerScript>().boost = true;
    }

    public override void BeginCooldownboost(GameObject player)
    {
        player.GetComponent<PlayerScript>().boost = false;
    }
}
