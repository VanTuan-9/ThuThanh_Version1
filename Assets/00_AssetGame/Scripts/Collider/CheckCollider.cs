using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheckCollider : MonoBehaviour, ICollider
{
    protected CharacterBase character;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterBase>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
    }

    protected virtual void OnTriggerStay2D(Collider2D other) {
        OnCollide(other);
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {

    }

    public abstract void OnCollide(Collider2D other);
}
