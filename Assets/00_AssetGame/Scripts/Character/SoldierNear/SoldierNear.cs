using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

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
    public override void Attack()
    {
        base.Attack();
        isMoveToEnemy = false;
    }

}
