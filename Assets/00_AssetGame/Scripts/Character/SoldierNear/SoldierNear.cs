using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.PackageManager;

public class SoldierNear : CharacterBase
{
    // phương thức tấn công quái : quái có collider
    // + khi lính chạm vào quái thì dừng lại
    // + khi dừng lại sẽ thực hiện tấn công quái
    // thực hiện anim x
    // tạo 1 thuộc tính hồi chiêu x
    // code sau bao nhiêu thoi gian sẽ tấn công tiếp x
    // code gọi hàm BeAttack(chỉ số tấn công của lính) ở quái  --
    // đổi mục tiêu quái mới

    // phương thức bị quái tấn 
    [SerializeField] protected Vector2 boxSize;
    [SerializeField] protected Transform poinAttack;
    [SerializeField] protected LayerMask layerMask;
    protected override void Attacking()
    {
        RaycastHit2D hit = Physics2D.BoxCast(poinAttack.position, boxSize, 0f, Vector2.zero, layerMask);

        if (hit.collider && !hit.collider.isTrigger)
            Damage(hit.collider.gameObject);
    }
    protected virtual void Damage(GameObject enemy)
    {
        enemy.GetComponent<CharacterBase>().BeAttacked(attackNumber);
    }
}
