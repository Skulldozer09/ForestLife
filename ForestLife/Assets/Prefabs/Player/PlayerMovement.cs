using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool DebugMode = false;
    public GameObject debugAttackPoint;
    public float debugAttackDamage = 20f;
    //public LayerMask blockLayers;
    public Sprite DebugHitSprite;
    public float movementSpeed = 5f;
    public Rigidbody rb;
    Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        if (!DebugMode)
        {
            GetComponentInChildren<DebugDetectCollision>().enabled = false;
            GetComponentInChildren<DebugDetectCollision>().GetComponentInParent<SpriteRenderer>().sprite = null;
            GetComponentInChildren<DebugDetectCollision>().GetComponentInParent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponentInChildren<DebugDetectCollision>().enabled = true;
            GetComponentInChildren<DebugDetectCollision>().GetComponentInParent<SpriteRenderer>().sprite = DebugHitSprite;
            GetComponentInChildren<DebugDetectCollision>().GetComponentInParent<BoxCollider>().enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }
    public void DebugAttack(GameObject Target)
    {
        Target.GetComponent<BlockData>().DamageMe(debugAttackDamage, gameObject);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector.normalized * movementSpeed * Time.fixedDeltaTime);
    }

}
