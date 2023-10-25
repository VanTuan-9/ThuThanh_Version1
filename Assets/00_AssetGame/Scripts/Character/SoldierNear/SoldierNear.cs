using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class SoldierNear : CharacterBase
{
    [SerializeField] Collider2D collider2D;
    private object idTarget;

    public GameObject enemyTarget;
    private bool isMoveEnemy = true;
    private SoldierFar quai;
    private bool isAttack = false, isHoiChieu = false;
    public override void Start()
    {
        base.Start();
        //Run();

    }

    private void OnEnable() {
    }


    public void MoveToStart(Vector2 positionStart) {    // positionStart là điểm để lính di chuyển đến
        float timeMove = Vector2.Distance(transform.position, positionStart) / base.GetSpeed();

        transform.DOMove(positionStart, timeMove).SetEase(Ease.Linear);
    }
    // viết 1 phương thức di chuyển tự trụ đến điểm bắt đầu

    public void ActiveMoveToEnemy(GameObject enemy) {
        enemyTarget = enemy;
        isMoveEnemy = true;
    }

    private void MoveToEnemy() {
        Vector2 pos = Vector3.Normalize(enemyTarget.transform.position - transform.position);
        transform.Translate(pos * base.GetSpeed());
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("enemy") ) {
            isHoiChieu = false;
            isAttack = true;
            if(CheckKhoangCach(quai.gameObject, other.gameObject))
                quai = other.GetComponent<SoldierFar>();
        }
    }

    private bool CheckKhoangCach(GameObject quai1, GameObject quaiMoiVao) {
        if(Vector2.Distance(transform.position, quai1.transform.position) > Vector2.Distance(transform.position, quaiMoiVao.transform.position))
            return true;
        return false;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("enemy")) {
            isAttack = false;
        }
    }
    // phương thức tấn công quái : quái có collider
    // + khi lính chạm vào quái thì dừng lại
    // + khi dừng lại sẽ thực hiện tấn công quái
    // thực hiện anim x
    // tạo 1 thuộc tính hồi chiêu x
    // code sau bao nhiêu thoi gian sẽ tấn công tiếp x
    // code gọi hàm BeAttack(chỉ số tấn công của lính) ở quái  --
    // đổi mục tiêu quái mới

    // phương thức bị quái tấn 
    public override void Attack()
    {
        base.Attack();
        isMoveEnemy = false;
        quai.BeAttacked(base.GetAttackNumber());
        // tắt tính năng di chuyển
    }

    IEnumerator DelayHoiChieu() {
        yield return new WaitForSeconds(base.GetTimeHoiChieu());
        isHoiChieu = false;
    }
    public override void BeAttacked(int attackNumber)
    {
        base.BeAttacked(attackNumber);
    }

    public override void Die()
    {
        base.Die();
    }

    public override void Update()
    {
        //base.Update();
        if(isMoveEnemy) {
            MoveToEnemy();
        }
        if(isAttack && !isHoiChieu) {
            Attack();
            isHoiChieu = true;
            StartCoroutine(DelayHoiChieu());
        }
    }
    public override void Run()
    {
        base.Run();
        idTarget = transform.DOPath(GameManager.Instance.GetListPoint().ToArray(), 4, PathType.CatmullRom, PathMode.TopDown2D).SetEase(Ease.Linear).target;
    }
}
