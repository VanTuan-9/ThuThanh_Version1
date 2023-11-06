using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    //private List<CharacterBase> soldiers = new List<CharacterBase>();
    public GroundSoldierMove groundSoldierMove;
    private List<GameObject> enemy = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !collision.isTrigger)
        {
            enemy.Add(collision.gameObject);
            // foreach (CharacterBase soldier in soldiers)
            // {
            //     soldier.ChangeCharacterIsSeen(enemy);
            // }
            foreach (Transform soldier in groundSoldierMove.transform)
            {
                soldier.gameObject.GetComponent<CharacterBase>().ChangeCharacterIsSeen(enemy);
            }
            groundSoldierMove.ChangeCharacterIsSeen(enemy);
        }
        // if(collision.CompareTag("soldier") && !collision.isTrigger){
        //     soldiers.Add(collision.gameObject.GetComponent<CharacterBase>());
        // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !collision.isTrigger)
        {
            enemy.Remove(collision.gameObject);
            // foreach (CharacterBase soldier in soldiers)
            // {
            //     soldier.ChangeCharacterIsSeen(enemy);
            // }
            foreach (Transform soldier in groundSoldierMove.transform)
            {
                soldier.gameObject.GetComponent<CharacterBase>().ChangeCharacterIsSeen(enemy);
            }
            groundSoldierMove.ChangeCharacterIsSeen(enemy);
        }
        // if(collision.CompareTag("soldier") && !collision.isTrigger){
        //     soldiers.Remove(collision.gameObject.GetComponent<CharacterBase>());
        // }
    }
}
