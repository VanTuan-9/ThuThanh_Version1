using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CheckColliderFortress : CheckCollider
{
    public override void OnCollide(Collider2D other)
    {
        if (other.CompareTag("enemy"))
            character.Attack();
    }
}
