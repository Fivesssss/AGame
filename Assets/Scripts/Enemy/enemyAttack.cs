using Pathfinding;
using System.Collections;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] int damageModifier = 1;
    [SerializeField] float knockbackForce = 5f;
    private Vector2 knockbackDirection;

    private bool isAttacking = false;

    [SerializeField] private Animator enemyAnim;

    [SerializeField] private bool hasAttackAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collect player scripts
            isAttacking = true;
            GameObject player = collision.gameObject;
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            //knockback direction logic
            knockbackDirection = (player.transform.position - transform.position).normalized;

            if (playerHealth != null)
            {
                if(hasAttackAnimation)
                {
                    enemyAnim.SetBool("isAttack", true);
                }

                playerHealth.takeDamage(damageModifier);
                
                StartCoroutine(playerKBcooldown(playerMovement, playerRb, playerHealth));  
            }
        }
    }

    private IEnumerator playerKBcooldown(PlayerMovement playerMovement, Rigidbody2D playerRb, PlayerHealth playerHealth)
    {
        //disable player movment and apply knockback force and set the hit animation
        playerHealth.setPlayerHitAnim();
        playerMovement.enabled = false;
        playerRb.linearVelocity = knockbackDirection * knockbackForce;

        yield return new WaitForSeconds(2f);

        //make sure that the enemy has an attack animation in the first place
        if(hasAttackAnimation)
        {
            enemyAnim.SetBool("isAttack", false);
        }
        playerHealth.disablePlayerHitAnim();
        //reset player velocity and re-enable player movement
        playerRb.linearVelocity = Vector2.zero;
        playerMovement.enabled = true;
        isAttacking = false;
    }

    public bool isAttackingState()
    {
        return isAttacking;
    }
}
