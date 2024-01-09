using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingVoid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Debug.Log("here");
            SpawnObject.Instance.listObj.RemoveAt(0);
            BreakTheBlockIngameData.Instance.DecreaseHealth();
            Destroy(gameObject);
            
        }
    }
}

