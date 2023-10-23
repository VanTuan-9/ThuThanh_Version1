using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<Transform> listPoints = null;
    void Start()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    public List<Vector3> GetListPoint() {
        List<Vector3> listPos = new List<Vector3>();
        foreach(Transform point in listPoints)
            listPos.Add(point.position);
        return listPos;
    }
}
