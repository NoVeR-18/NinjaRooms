using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAttack : MonoBehaviour
{
    [SerializeField]
    protected float attackTimer;
    [SerializeField]
    private float coolDown;
    [SerializeField]
    protected bool isAttacking = false;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected int damageToEnemy;

    void Start()
    {
        attackTimer = 0;
        coolDown = 1.0f;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isAttacking)
        {
        }
        else
        {
            //animator.SetBool("attack", false);
        }
    }
    void FixedUpdate()
    {
        AttackTimer();
    }
    private void AttackTimer()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (Attacking())
        {
            //animator.SetBool("attack", true);
            isAttacking = true;
            attackTimer = coolDown;
        }
        else
        {
            isAttacking = false;
        }
    }
    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && isAttacking)
            collider.GetComponent<PlayersHealth>().AddjustCurrentHealth(damageToEnemy);
    }
    protected virtual bool Attacking()
    {
        if (attackTimer == 0)
            return true;
        else
            return false;
    }
}
