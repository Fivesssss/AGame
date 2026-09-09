using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using Pathfinding;


public class WeaponController : MonoBehaviour
{
    [SerializeField] int damageModifier = 1;
    [SerializeField] float knockbackForce = 5f; // Adjust the knockback force as needed

    [SerializeField] Animator playerAnim;


    private bool isAttacking = false;
    private Vector2 knockbackDirection;
    private PolygonCollider2D swordCollider;
    void Start()
    {
        swordCollider = GetComponent<PolygonCollider2D>();
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking){
            isAttacking = true;
            StartCoroutine(DisableCollider());
        }
    }

    private IEnumerator DisableCollider()
    {
        playerAnim.SetBool("isAttacking", true);
        swordCollider.enabled = true;
        yield return new WaitForSeconds(1f); //replace with sword animation length
        isAttacking = false;
        swordCollider.enabled = false;
        playerAnim.SetBool("isAttacking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the collider is an enemy
        if (collision.CompareTag("Enemy")) {
            //get the enemy gameobject and call the takeDamage function
            GameObject enemy = collision.gameObject;
            Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
            enemyHealth enemyHealthScript = enemy.GetComponent<enemyHealth>();
            AIPath enemyAIPath = enemy.GetComponent<AIPath>();

            knockbackDirection = (enemy.transform.position - transform.position).normalized; //this will calculate the direction

            if (enemyHealthScript != null) {
                enemyHealthScript.takeDamage(damageModifier);
            }
            if (enemyRB != null)
            {
                // Add knockback effect
                enemyRB.linearVelocity = knockbackDirection * knockbackForce;
                enemyHealthScript.enemyKnockBack();

            }
        }

    }


    public bool isAttackingState()
    {
        return isAttacking;
    }
}
