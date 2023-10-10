using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingVoid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Destroy(collision.gameObject);
            Score.Instance.DecreaseHealth();
        }
    }
}

