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
<<<<<<< HEAD
=======
    public Animator animator;
    public SpriteRenderer spriteRef;
>>>>>>> da703e5a77ff31c4ab4f39f6d0a233bd5915e87f
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
<<<<<<< HEAD
=======
        animator.SetFloat("Horizontal", movementVector.x);
        if (movementVector.x >= 0)
        {
            spriteRef.flipX = false;
        }
        else
        {
            spriteRef.flipX = true;
        }
        animator.SetFloat("Vertical", movementVector.y);
        animator.SetFloat("Speed", movementVector.sqrMagnitude);
>>>>>>> da703e5a77ff31c4ab4f39f6d0a233bd5915e87f
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
