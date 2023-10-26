using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    [Header("==Character attributes==")]
    [Tooltip("chi so tan cong")]
    [SerializeField] protected int attackNumber = 1;

    [Tooltip("chi so HP")]
    [SerializeField] protected int hpNumber = 1;

    [Tooltip("chi so phong thu")]
    [SerializeField] protected int defNumber = 1;

    [Tooltip("chi so toc do di chuyen")]
    [SerializeField] protected float speedNumber = 1;
    
    [Tooltip("chi so hoi chieu khi tan cong")]
    [SerializeField] protected float timeReloadSkill = 1;

    [Tooltip("component animator controller")]
    [SerializeField] protected AnimatorController animatorController;

    [SerializeField] protected CapsuleCollider2D collider2D;

    //--------------------------
    protected bool isMoveToEnemy = false;
    protected bool isMoveToStart = true;
    protected bool isAttack = false;

    protected bool isPacingRight = true;

    protected List<GameObject> enemyIsSeen = new List<GameObject>();

    protected virtual void Start() {

    }
    private void OnEnable()
    {
        if (!isMoveToStart) return;
        animatorController.ChangeAnim(AnimType.MOVE);
        this.MoveToStart(positionStart());
    }

    protected virtual void Update() {

    }


    public virtual void Attack()
    {
        if(isAttack && )
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
        isMoveToEnemy = false;
        isMoveToStart = false;
        StartCoroutine(DelayDie());
    }

    public virtual void RotateCharacter() {
        if (isPacingRight && transform.position.x < 0) {
            ChangeLocalScaleToRotateCharacter();
            isPacingRight = false;
        }
        else if (!isPacingRight && transform.localScale.x > 0) {
            ChangeLocalScaleToRotateCharacter();
            isPacingRight = true;
        }
    }
    private void ChangeLocalScaleToRotateCharacter()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public virtual void Run()
    {
        if (!isMoveToEnemy) return;
        animatorController.ChangeAnim(AnimType.MOVE);
        this.MoveToEnemy(SelectEnemyToMove());
    }

    public virtual void UseSkill(SkillType skillType)
    {
        
    }

    public void BuffIndex()
    {
    }

    protected IEnumerator DelayDie() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    protected virtual void MoveToStart(Vector2 positionStart)
    {   
        float timeMove = Vector2.Distance(transform.position, positionStart) / speedNumber;
        transform.DOMove(positionStart, timeMove).SetEase(Ease.Linear);
    }
    protected virtual void MoveToEnemy(GameObject enemyNear)
    {
        Vector2 pos = Vector3.Normalize(enemyNear.transform.position - transform.position);
        transform.Translate(pos * speedNumber);
    }
    protected virtual void ChangeEnemyIsSeen()
    {
        //dong bo enemy ma tru nhin thay voi linh
    }
    protected virtual GameObject SelectEnemyToMove()
    {
        GameObject enemyNear = enemyIsSeen[0];
        foreach(GameObject enemy in enemyIsSeen)
        {
            if(CompareWithEnemy(enemy,enemyNear))
                enemyNear = enemy;
        }
        return enemyNear;
    }
    private bool CompareWithEnemy(GameObject enemy, GameObject enemyNear)
    {
        float distanceEnemyNear = Vector2.Distance(transform.position, enemy.transform.position);
        float distanceEnemy = Vector2.Distance(transform.position, enemyNear.transform.position);
        if (distanceEnemy < distanceEnemyNear)
            return true;
        return false;
    }
    private Vector2 positionStart()
    {
        return new Vector2(0,0);
    }
    private bool isReloadSkill()
    {
        
        if
    }
}
