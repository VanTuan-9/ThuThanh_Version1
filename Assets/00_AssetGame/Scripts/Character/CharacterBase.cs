using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    [Header("==Character attributes==")]
    [Tooltip("chi so tan cong")]
    [SerializeField] private int attackNumber = 1;

    [Tooltip("chi so HP")]
    [SerializeField] private int hpNumber = 1;

    [Tooltip("chi so phong thu")]
    [SerializeField] private int defNumber = 1;

    [Tooltip("chi so toc do di chuyen")]
    [SerializeField] private float speedNumber = 1;
    
    [Tooltip("chi so hoi chieu khi tan cong")]
    [SerializeField] private float timeReloadSkill = 1;

    [Tooltip("component animator controller")]
    [SerializeField] private AnimatorController animatorController;

    [SerializeField] private CapsuleCollider2D collider2D;
    public virtual void Start() {

    }

    public virtual void Update() {

    }

    public int GetAttackNumber() => attackNumber;
    public float GetTimeHoiChieu() => timeReloadSkill;
    public float GetSpeed() => speedNumber;

    public virtual void Attack() {
        Debug.Log(true);
        animatorController.ChangeAnim(AnimType.ATTACK);
        
    }

    public virtual void BeAttacked(int attackNumber) {
        animatorController.ChangeAnim(AnimType.BEATTACKED);
        int attackNumberNew = attackNumber - defNumber;
        if(attackNumberNew < 0)
            attackNumberNew = 0;
        hpNumber -= attackNumberNew;
    }

    public virtual void Die() {
        animatorController.ChangeAnim(AnimType.DIE);
        collider2D.enabled = false;
        StartCoroutine(DelayDie());
    }

    public virtual void RotatePlayer() {
        Debug.Log(true);
    }

    public virtual void Run() {
        animatorController.ChangeAnim(AnimType.MOVE);

    }

    public virtual void UseSkill(SkillType skillType)
    {
        
    }

    public virtual void BuffIndex()
    {
        
    }
    
    private IEnumerator DelayDie() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
