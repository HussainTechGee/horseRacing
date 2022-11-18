using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public GameObject DestroyHurdelPrefab;
    public GameObject[] opponent;
    public bool boost, freez, freezOthers, destroyOthers, destroyer;
    public static PlayerScript playerinstance;
    public Movement movement;
    int current;
    private void Start()
    {
        if (playerinstance == null)
        {
            playerinstance = this;
        }
        movement = Movement.insatnce;
        opponent = GameObject.FindGameObjectsWithTag("player");
    }
    private void FixedUpdate()
    {
        #region  UsingPlayer'sFreezingSkill
        if (!destroyer)
        {
            for (int i = 0; i < opponent.Length; i++)
            { //Getting current player which uses the Skill
                if (opponent[i].GetComponent<PlayerScript>().freezOthers)
                {
                    current = i;
                }
            }
            if (opponent[current].GetComponent<PlayerScript>().freezOthers)
            {  //freezing other Players
                for (int i = 0; i < opponent.Length; i++)
                {
                    if (i != current)
                    {
                        opponent[i].GetComponent<PlayerScript>().freez = true;
                        opponent[i].GetComponent<PlayerScript>().boost = false;
                    }
                }
                // foreach (GameObject opp in opponent)
                // {
                //     if (!opp.GetComponent<PlayerScript>().freezOthers && !opp.GetComponent<PlayerScript>().freez)
                //     {
                //         opp.GetComponent<PlayerScript>().freez = true;
                //         opp.GetComponent<PlayerScript>().boost = false;
                //     }
                // }
            }
            else
            { //Unfreezing other players
                for (int i = 0; i < opponent.Length; i++)
                {
                    // if (opponent[i].GetComponent<PlayerScript>().freez)
                    // {
                    opponent[i].GetComponent<PlayerScript>().freez = false;
                    // }
                }
                //     foreach (GameObject opp in opponent)
                //     {  
                //         if (opp.GetComponent<PlayerScript>().freez)
                //         {
                //             opp.GetComponent<PlayerScript>().freez = false;
                //         }
                //     }
            }
        }
        #endregion
        #region  Moving Player
        if (!freez)
        {
            movement.moveforward(gameObject, boost);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            movement.freezmovement(gameObject);
        }
        #endregion
        #region  UsingPlaye'sDestroyingSkill
        if (destroyOthers)
        {
            GameObject destroyerprefab = (GameObject)Instantiate(DestroyHurdelPrefab, new Vector3(-0.1299f, -3.5f, transform.position.z - 2.5f), Quaternion.identity);
            destroyOthers = false;
        }
        if (destroyer)
        {
            movement.freezmovement(gameObject);
        }
        #endregion
    }




}
