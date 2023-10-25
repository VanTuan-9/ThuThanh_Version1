using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{

    [SerializeField] private GameObject soldierNearPrefab;
    [SerializeField] private Transform grLinh;
    [SerializeField] private int limitLinh = 3;

    private List<SoldierNear> listLinhs;
    private SoldierNear linh;

    private Vector2 posStart;
    void Start()
    {
        listLinhs = new List<SoldierNear>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitTru() {
        for (int i = 0; i < limitLinh; i++)
        {
            linh = Instantiate(soldierNearPrefab, transform.position, Quaternion.identity, grLinh).GetComponent<SoldierNear>();
            linh.MoveToStart(posStart);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy")) {
            QuaiXamNhap(other.gameObject);
        }
    }

    private void QuaiXamNhap(GameObject gameObject)
    {
        foreach(SoldierNear item in listLinhs) {
            item.ActiveMoveToEnemy(gameObject);
        }
    }
}
