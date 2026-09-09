using UnityEngine;
using Pathfinding;

public class enemyDetectionZone : MonoBehaviour
{
    private GameObject enemy;

    private AIPath aiPathScript;

    private bool isPlayerInRange = false;

    [SerializeField] private Animator enemyAnim;

    [SerializeField] enemyAttack enemyAttackScript;

    private void Start()
    {
        enemy = transform.parent.gameObject;
        aiPathScript = enemy.GetComponent<AIPath>();
    }

    private void Update()
    {
        //ensure that the enemy is not flipped whilst in attacking state, and only flips when moving left or right
        if (aiPathScript.desiredVelocity.x > 0.1f && !enemyAttackScript.isAttackingState()) 
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (aiPathScript.desiredVelocity.x < -0.1f && !enemyAttackScript.isAttackingState())
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("Hit");


            isPlayerInRange = true;
            //allow the enemy to move
            aiPathScript.canMove = true;
            enemyAnim.SetBool("isWalking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            AIPath aiPathScript = enemy.GetComponent<AIPath>();
            aiPathScript.canMove = false;

            isPlayerInRange = false;
            enemy.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            enemyAnim.SetBool("isWalking", false);
        }
    }

    public bool getIsPlayerInRange() 
    {
        return isPlayerInRange;
    }
}
