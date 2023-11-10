using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public int maxHealth = 30;
    int currentHealth;
    public GameObject player;
    public float speed;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask playerC;
    public int attackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "player") //Weird error happened here, now fixed
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerC);

        foreach (Collider Player in hitPlayer)
        {
            Player.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
