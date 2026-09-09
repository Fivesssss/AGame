using Pathfinding;
using System.Collections;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    //setHealth is base value of health
    [SerializeField] private int setHealth;

    //actual health value of the enemy
    private int health;

    [SerializeField] private bool hasCipher; // Whether the enemy has a cipher to drop upon death

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject enemyHeldCipher; // Reference to the cipher object held by the enemy

    [SerializeField] private Animator enemyAnim; // Reference to the enemy animator script

    [SerializeField] private AIPath enemyAiPath; // Reference to the enemy AI path script

    [SerializeField] private enemyDetectionZone enemyDetection; // Reference to the enemy detection zone script

    void Start()
    {
        //set health to the value of setHealth
        health = setHealth;
        enemyHeldCipher.SetActive(false);
    }

    //damage script
    public void takeDamage(int damageModifier) 
    {
        health -= damageModifier;
        if (health <= 0) 
        {
            StartCoroutine(enemyDeathAnimation()); // Start the death animation coroutine
        }
    }

    private IEnumerator enemyDeathAnimation() 
    {
        enemyAnim.SetBool("isDead", true); // Trigger the death animation

        yield return new WaitForSeconds(3f); // Wait for 3 second before deactivating the enemy

        if (hasCipher)
        {
            enemyHeldCipher.transform.position = transform.position; // Set the position of the cipher object to the enemy's position
            enemyHeldCipher.SetActive(true); // Activate the cipher object when the enemy is destroyed
        }
        enemyAnim.SetBool("isDead", false); // Reset the death animation state
        Destroy(gameObject);
    }

    public void enemyKnockBack() 
    {
        StartCoroutine(enemyKBcooldown(enemyAiPath, this, enemyDetection));
    }

    // Coroutine to handle enemy knockback cooldown
    private IEnumerator enemyKBcooldown(AIPath enemyAiPath, enemyHealth enemyHealthScript, enemyDetectionZone enemyDetection)
    {
        enemyHealthScript.setHitAnimation();
        enemyAiPath.canMove = false;

        yield return new WaitForSeconds(3f);

        this.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Reset the enemy's velocity to zero
        if (enemyDetection.getIsPlayerInRange()) 
        {
            enemyAiPath.canMove = true;
        }
        enemyHealthScript.disableHitAnimation();
    }

    public void setHitAnimation()
    {
        enemyAnim.SetBool("isHit", true);
    }

    public void disableHitAnimation()
    {
        enemyAnim.SetBool("isHit", false);
    }
}
