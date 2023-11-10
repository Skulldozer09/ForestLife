using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDetectCollision : MonoBehaviour
{
    public string TagToTestDmg = "Block";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagToTestDmg)
        {
            gameObject.GetComponentInParent<PlayerMovement>().DebugAttack(other.gameObject);
        }
    }
}
