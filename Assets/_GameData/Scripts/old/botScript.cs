using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class botScript : MonoBehaviour
{
    Movement movement;
    public float turnspeed, Amount;
    public static botScript _botscript;

    private void Start()
    {
        if (_botscript == null)
        {
            _botscript = this;
        }
        movement = Movement.insatnce;
        StartCoroutine(useSkill());
        StartCoroutine(moveRandom());
    }
    private void Update()
    {

    }

    private IEnumerator useSkill()
    {
        int time = Random.Range(0, 2);
        yield return new WaitForSeconds(time);
        if (time % 2 == 0)
        {
            if (!gameObject.GetComponent<SkillHolder>().usefreezingability && gameObject.GetComponent<SkillHolder>().canUsefreezingSkill)
            {
                gameObject.GetComponent<SkillHolder>().usefreezingability = true;
                gameObject.GetComponent<SkillHolder>().canUsefreezingSkill = false;
            }
        }
        else
        {
            if (!gameObject.GetComponent<SkillHolder>().useboostability && gameObject.GetComponent<SkillHolder>().canUseboostingSkill)
            {
                gameObject.GetComponent<SkillHolder>().useboostability = true;
                gameObject.GetComponent<SkillHolder>().canUseboostingSkill = false;

            }
        }
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(useSkill());
    }
    [SerializeField]
    Transform[] positions;
    float duration;
    private IEnumerator moveRandom()
    {

        yield return new WaitForSeconds(.1f);

        int randomnum = Random.Range(0, positions.Length);
        int duration = Random.Range(0, 2);

        // float movementAmountX = 1.2f * Time.deltaTime * turnspeed * randomnum;
        // float movementAmountY = 1.2f * turnspeed;
        // movementAmountX = Mathf.Clamp(movementAmountX, -Amount, Amount);
        // transform.Translate(movementAmountX, 0, 0);
        if (!gameObject.GetComponent<PlayerScript>().freez)
        {
            transform.DOMoveX(positions[randomnum].position.x, .5f);
        }

        yield return new WaitForSeconds(duration);
        StartCoroutine(moveRandom());
    }

}
