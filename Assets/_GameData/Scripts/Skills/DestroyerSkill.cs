using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu]
public class DestroyerSkill : Skills
{
    public override void ActivateDestroyer(GameObject player)
    {
        player.GetComponent<PlayerScript>().destroyer = true;
    }

    public override void BeginCooldownDestroyer(GameObject player)
    {
        player.GetComponent<PlayerScript>().destroyer = false;
    }
}
