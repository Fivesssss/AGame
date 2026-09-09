using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int setHealth = 5;

    [SerializeField] private HealthUIScript healthUIScript;

    [SerializeField] Animator playerAnim;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = setHealth;
    }

    public void healPlayer(int amount)
    {
        //makes sure that player is healed up until the max health and not over it
        if (health + amount <= setHealth) {
            health += amount;
        }
        else {
            //if amount heals player over max, just set health to max
            health = setHealth;
        }
        healthUIScript.addHealthUI();
    }

    public void takeDamage(int amount)
    {
            health -= amount;
            healthUIScript.removeHealthUI();
        if(health <= 0) {
            StartCoroutine(playerDeathAnim()); // Start the death animation coroutine
        }
    }

    public void setPlayerHitAnim()
    {
        playerAnim.SetBool("isHit", true);
    }

    public void disablePlayerHitAnim() 
    {
        playerAnim.SetBool("isHit", false);
    }

    private IEnumerator playerDeathAnim() 
    {
        playerAnim.SetBool("isDead", true); // Trigger the death animation
        yield return new WaitForSeconds(3f); // Wait for 3 second before deactivating the player
        playerAnim.SetBool("isDead", false); // Reset the death animation state
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");
    }

    public int getHealth() 
    {
        return health;
    }
}
