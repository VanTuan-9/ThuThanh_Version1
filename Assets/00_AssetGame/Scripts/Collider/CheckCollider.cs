using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour, ICollider
{
    // collider su dung loai onTrigger
    [SerializeField] private CharacterType characterType;

    //tag, layer, name
    private string tag = "";
    
    private void Start() {
        switch(characterType) {
            case CharacterType.SOLDIER: 
            tag = "enemy";
            break;
            case CharacterType.FORTRESS:
            tag = "enemy";
            break;
            case CharacterType.ENEMY:
            tag = "soldier";
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(tag)) {
            // code chuc nang
        }
    }

    private void OnTriggerStay2D(Collider2D other) {

    }

    private void OnTriggerExit2D(Collider2D other) {

    }

    public void OnCollidePlayer()
    {
        throw new System.NotImplementedException();
    }

    public void OnCollideFortress()
    {
        throw new System.NotImplementedException();
    }

    public void OnCOllideEnemy()
    {
        throw new System.NotImplementedException();
    }
}
