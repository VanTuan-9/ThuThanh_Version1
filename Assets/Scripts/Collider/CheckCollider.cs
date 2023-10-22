using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour, ICollider
{
    // collider su dung loai onTrigger
    [SerializeField] private CharacterType characterType;

    
    
    private void Start() {
        switch(characterType) {
            case CharacterType.PLAYER: 
            //
            break;
            case CharacterType.FORTRESS:
            //
            break;
            case CharacterType.ENEMY:
            // 
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
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
