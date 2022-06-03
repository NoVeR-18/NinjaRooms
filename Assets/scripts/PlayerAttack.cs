using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PersonAttack
{
    PlayerAttack()
    {
        damageToEnemy = 10;
    }

    protected override void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Enemy" && isAttacking)
            collider.GetComponent<EnemyHealth>().AddjustCurrentHealth(damageToEnemy);
    }
    protected override bool Attacking()
    {
        if (Input.GetKeyDown("f") && attackTimer == 0)
        {
            animator.SetBool("attack", true);
            return true;
        }
        else
        {
            animator.SetBool("attack", false);
            return false;
        }
    }

}