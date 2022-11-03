using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    public static Movement insatnce;
    private InputSystem _inputSystem;
    [SerializeField] private float turnspeed = 0.5f;
    [SerializeField] private float Amount = 1f, runningSpeed = 5;
    public Transform rightpoint, leftpoint;
    GameObject mainplayer;
    public bool mainPlayer;
    private void Awake()
    {
        if (insatnce == null)
        {
            insatnce = this;
        }
        _inputSystem = GetComponent<InputSystem>();
        if (mainPlayer)
        {
            mainplayer = this.gameObject;
        }
    }
    private void Update()
    {
        #region Moveleft&Right
        if (mainPlayer && !mainplayer.GetComponent<PlayerScript>().freez)
        {
            float movementAmountX = Time.deltaTime * turnspeed * _inputSystem.MoveFactorX;
            float movementAmountY = Time.deltaTime * turnspeed * _inputSystem.MoveFactorY;
            movementAmountX = Mathf.Clamp(movementAmountX, -Amount, Amount);
            movementAmountY = Mathf.Clamp(movementAmountY, -Amount, Amount);
            transform.Translate(movementAmountX, 0, 0);
        }
        // if (!mainPlayer)
        // {
        // float randomnum = Random.Range(-2, 2);
        // float movementAmountX = 1.2f * Time.deltaTime * turnspeed * randomnum;
        // // float movementAmountY = 1.2f * turnspeed;
        // movementAmountX = Mathf.Clamp(movementAmountX, -Amount, Amount);
        // transform.Translate(movementAmountX, 0, 0);
        // }
        #endregion
        if (transform.position.x <= leftpoint.position.x)
        {
            transform.position = new Vector3(leftpoint.position.x + .04f, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= rightpoint.position.x)
        {
            transform.position = new Vector3(rightpoint.position.x - .04f, transform.position.y, transform.position.z);
        }
    }
    public void moveforward(GameObject player, bool boost)
    {
        if (!boost)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.forward * runningSpeed;
            // if (mainPlayer)
            // {
            //     player.transform.GetChild(3).GetComponent<Rigidbody>().velocity = Vector3.forward * runningSpeed;
            // }
            player.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.forward * (runningSpeed * 4);
            player.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public void freezmovement(GameObject player)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.forward * (runningSpeed / 8);
        player.transform.GetChild(1).gameObject.SetActive(true);
    }
}