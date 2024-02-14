using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    /*--------------------THUOC_TINH---------------------*/

    [Header("==Character attributes==")]
    [Tooltip("chi so tan cong")]
    [SerializeField] protected int attackNumber = 1;

    [Tooltip("chi so HP")]
    [SerializeField] protected int hpNumber = 10;

    [Tooltip("chi so phong thu")]
    [SerializeField] protected int defNumber = 0;

    [Tooltip("chi so toc do di chuyen")]
    [SerializeField] protected float speedNumber = 1;
    
    [Tooltip("chi so hoi chieu khi tan cong")]
    [SerializeField] protected float timeReloadSkill = 1;
    protected float time;
    /*--------------------GET_COMPONENT---------------------*/
    [Tooltip("component animator controller")]
    [SerializeField] protected AnimatorController animatorController;

    [Tooltip("component rigidbody2d")]
    [SerializeField] protected Rigidbody2D rb;

    /*--------------------CHECK_HANH_VI---------------------*/
    protected bool isMoveToEnemy = true;
    protected bool isPacingRight = true;

    protected List<GameObject> characterIsSeen = new List<GameObject>();
    Vector2 vectorDirection;

    object idTarget = null;

    protected virtual void Awake()
    {
        if (!animatorController)
            animatorController = this.GetComponent<AnimatorController>();
        if (!rb)
            rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        time = timeReloadSkill;
    }

    protected virtual void Update()
    {
        Run();
        RotateCharacter();
        Die();
    }

    /*--------------------RUN_TO_ENEMY------------------*/
    public virtual void Run()
    {
         bool characterIsSeenIsNull = characterIsSeen.Count == 0;
        if (isMoveToEnemy && !characterIsSeenIsNull){
            animatorController.ChangeAnim(AnimType.MOVE);
            this.MoveToEnemy(SelectEnemyToMove());
        }
    }

    protected virtual void MoveToEnemy(GameObject enemyNear)
    {
        VectorDirection(enemyNear.transform.position);
        Vector2 pos = Vector3.Normalize(enemyNear.transform.position - transform.position);
        transform.Translate(pos * speedNumber * Time.deltaTime);
    }

    public void ChangeCharacterIsSeen(List<GameObject> enemy)
    {
        characterIsSeen = enemy;
    }

    protected virtual GameObject SelectEnemyToMove()
    {
        GameObject enemyNear = characterIsSeen[0];
        foreach (GameObject enemy in characterIsSeen)
        {
            if (CompareWithEnemy(enemy, enemyNear))
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

    public void AniMove(){
        animatorController.ChangeAnim(AnimType.MOVE);
    }

    /*--------------------ROTATECHARACTER---------------*/
    public void VectorDirection(Vector2 destination)
    {
        Vector2 startingPoint = transform.position;
        vectorDirection = destination - startingPoint;
    }
    public virtual void RotateCharacter()
    {
        if (isPacingRight && vectorDirection.x < 0)
        {
            ChangeLocalScaleToRotateCharacter();
            isPacingRight = false;
        }
        else if (!isPacingRight && vectorDirection.x > 0)
        {
            ChangeLocalScaleToRotateCharacter();
            isPacingRight = true;
        }
    }

    private void ChangeLocalScaleToRotateCharacter()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    /*--------------------ATTACK------------------------*/
    public virtual void Attack()
    {
        if (IsReloadSkill())
        {
            isMoveToEnemy = false;
            animatorController.ChangeAnim(AnimType.ATTACK);
            Attacking();
            Debug.Log(hpNumber);
        }
    }

    private bool IsReloadSkill()
    {
        time += Time.deltaTime;
        if (time > timeReloadSkill)
        {
            time = 0;
            return true;
        }
        return false;
    }

    protected abstract void Attacking();

    public virtual void StopAttacking()
    {
        isMoveToEnemy = true;
    }
    /*--------------------BEATTACK----------------------*/
    public virtual void BeAttacked(int attackNumber)
    {
        animatorController.ChangeAnim(AnimType.BEATTACKED);
        int attackNumberNew = attackNumber - defNumber;
        if (attackNumberNew < 0)
            attackNumberNew = 0;
        hpNumber -= attackNumberNew;
    }

    /*--------------------USESKILL----------------------*/
    public virtual void UseSkill(SkillType skillType)
    {

    }

    /*--------------------DIE---------------------------*/

    public virtual void Die() {
        if (hpNumber > 0) return;
        animatorController.ChangeAnim(AnimType.DIE);
        GetComponent<Collider2D>().enabled = false;
        isMoveToEnemy = false;
        StartCoroutine(DelayDie());
    }

    protected IEnumerator DelayDie() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
