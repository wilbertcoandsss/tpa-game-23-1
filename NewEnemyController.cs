using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyController : MonoBehaviour
{
    private Gammoth gammoth = new Gammoth();
    private Glavenus glavenus = new Glavenus();
    public NavMeshAgent agent;
    public float sightRange, attackRange;
    public bool playerInRange, playerInAttackRange;
    public Animator animator;
    private PlayerObject instance = PlayerObject.getInstance();
    private GameObject character;
    public GameObject potionLoot, meatLoot;
    public Collider enemy;
    private bool lootDropped;
    public LayerMask whatIsPlayer;
    private bool isAttack;
    public TextMeshProUGUI monsterTxt;
    void Start()
    {
        isAttack = false;

        if (gameObject.tag == "Gammoth")
        {
            gammoth.setName("Gammoth");
            gammoth.setHP(30f);
            monsterTxt.text = gammoth.getName();
        }
        else if (gameObject.tag == "Glavenus")
        {
            glavenus.setName("Glavenus");
            glavenus.setHP(600f);
            monsterTxt.text = glavenus.getName();
        }
    }

    void Update()
    {
        //if (enemyInstance.getHealth() == 0)
        //{
        //    animator.SetBool("IsChasing", false);
        //    animator.SetBool("IsDead", true);
        //    agent.SetDestination(transform.position);
        //    enemy.enabled = false;

        //    if (lootDropped == false)
        //    {
        //        int loot = Random.Range(0, 2);

        //        if (loot == 0)
        //        {
        //            Instantiate(potionLoot, transform.position, Quaternion.identity);
        //            lootDropped = true;
        //        }
        //        else if (loot == 1)
        //        {
        //            Instantiate(meatLoot, transform.position, Quaternion.identity);
        //            lootDropped = true;
        //        }
        //    }
        //}

        playerInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInRange && !playerInAttackRange) StateChasing();
        if (playerInAttackRange && playerInRange) StateAttacking();
    }

    public void StateChasing()
    {

        animator.SetBool("IsWalking", true);
        agent.SetDestination(character.transform.position);
    }

    public void StateAttacking()
    {
        animator.SetBool("IsWalking", false);

        int attack = Random.Range(0, 3);

        if (attack == 0)
        {
            animator.SetBool("IsAttack1", true);
            StartCoroutine(attackDelay());
        }
        else if (attack == 1)
        {
            animator.SetBool("IsAttack2", true);
            StartCoroutine(attackDelay2());
        }
        else if (attack == 2)
        {
            animator.SetBool("IsAttack3", true);
            StartCoroutine(attackDelay3());
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.gameObject.tag == "Player" && animator.GetBool("IsAttacking") == false && animator.GetBool("IsAttacking2") == false && animator.GetBool("IsDead") == false)
    //     {
    //         StateChasing();
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject.tag == "Player" && animator.GetBool("IsAttacking") == false && animator.GetBool("IsAttacking2") == false && animator.GetBool("IsDead") == false)
    //     {
    //         animator.SetBool("IsChasing", false);
    //     }
    // }

    // private void OnCollisionStay(Collision other) 
    // {
    //     if(other.gameObject.tag == "Player" && animator.GetBool("IsDead") == false)
    //     {
    //         StateAttacking();
    //     }
    // }

    // private void OnCollisionExit(Collision other) 
    // {
    //     if(other.gameObject.tag == "Player" && animator.GetBool("IsDead") == false)
    //     {
    //         StateChasing();
    //     }
    // }

    IEnumerator attackDelay()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsAttack1", false);
    }

    IEnumerator attackDelay2()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsAttack2", false);
    }
    IEnumerator attackDelay3()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsAttack3", false);
    }
}
