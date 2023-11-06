using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour, IAnimator
{
    [SerializeField] private Animator anim;
    public void ChangeAnim(AnimType animType) {
        switch(animType) {
            case AnimType.IDLE:
            Idle();
            break;
            
            case AnimType.MOVE:
            Move();
            break;
            
            case AnimType.ATTACK:
            Attack();
            break;
            
            case AnimType.ATTACK_SKILL_1:
            AttackSkill1();
            break;
            
            case AnimType.ATTACK_SKILL_2:
            AttackSkill2();
            break;
            
            case AnimType.DIE:
            Die();
            break;
            
            case AnimType.BEATTACKED:
            BeAttacked();
            break;
            
            case AnimType.LEVELUP:
            LevelUp();
            break;
            
            case AnimType.APPEAR:
            Appear();
            break;
            
        }
    }
    public void Appear()
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void AttackSkill1()
    {
        throw new System.NotImplementedException();
    }

    public void AttackSkill2()
    {
        throw new System.NotImplementedException();
    }

    public void BeAttacked()
    {
        anim.SetTrigger("BeAttack");
    }

    public void Die()
    {
        anim.SetTrigger("Die");
    }

    public void Idle()
    {
        anim.SetTrigger("Idle");
    }

    public void LevelUp()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        anim.SetTrigger("Move");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
