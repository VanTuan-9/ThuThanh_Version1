using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CheckColliderEnemy : CheckCollider
{
    public override void OnCollide(Collider2D other)
    {
        if (other.CompareTag("soldier"))
        {
            character.Attack();
            if (!other.gameObject.activeInHierarchy)
                character.StopAttacking();
        }
    }
}
