using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<PlayerMovement>().DebugAttack(other.gameObject);
    }
}
