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

    [Tooltip("component animator controller")]
    [SerializeField] private AnimatorController animatorController;

    public virtual void Start() {

    }

    public virtual void Update() {

    }

    public virtual void Attack() {
        Debug.Log(true);
        animatorController.ChangeAnim(AnimType.ATTACK);
    }

    public virtual void BeAttacked() {
        Debug.Log(true);
    }

    public virtual void Die() {
        Debug.Log(true);
    }

    public virtual void RotatePlayer() {
        Debug.Log(true);
    }

    public virtual void Run() {
        Debug.Log(true);
    }
}
