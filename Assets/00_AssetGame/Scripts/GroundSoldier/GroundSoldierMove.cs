using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class GroundSoldierMove : MonoBehaviour
{
    [SerializeField] private float speedNumber;
    bool isMoveToStartPoint = true;
    List<GameObject> characterIsSeen = new List<GameObject>();
    object idTarget = null;

    void Update(){
        SetIsMoveToStartPoint();
        MoveToStartPoint();
    }
    
    /*--------------------RUN_TO_START------------------*/
    private void MoveToStartPoint()
    {
        if (isMoveToStartPoint && characterIsSeen.Count == 0)
        {
            this.IsMovingToTheStartingPoint(StartPoint());
        }
    }

    private void IsMovingToTheStartingPoint(Vector3 positionStart)
    {
        VectorDirection(positionStart);
        Vector2 pos = Vector3.Normalize(positionStart - transform.position);
        transform.Translate(pos * speedNumber * Time.deltaTime);
    }

    void VectorDirection(Vector2 destination){
        foreach(Transform soldier in transform){
            soldier.gameObject.GetComponent<CharacterBase>().VectorDirection(destination);
            soldier.gameObject.GetComponent<CharacterBase>().AniMove();
        }
    }

    private Vector3 StartPoint()
    {
        return new Vector3(0, 0, 0);
    }
    public void ChangeCharacterIsSeen(List<GameObject> enemy)
    {
        characterIsSeen = enemy;
    }
    void SetIsMoveToStartPoint(){
        if(characterIsSeen.Count != 0){
            isMoveToStartPoint = false;
        }
    }
}
