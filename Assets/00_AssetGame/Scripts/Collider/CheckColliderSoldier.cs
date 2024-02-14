using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderSoldier : CheckCollider
{
    public override void OnCollide(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            character.Attack();
            Debug.Log("1");
            if (!other.gameObject.activeInHierarchy)
                character.StopAttacking();
        }
    }
}
