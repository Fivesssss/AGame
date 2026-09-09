using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    //[SerializeField] GameObject playerWeaponHitboxLeft;
    [SerializeField] GameObject playerWeaponHitboxRight;
    [SerializeField] Animator playerAnim;

    private WeaponController leftController;
    private WeaponController rightController;
    private Vector2 movement;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //leftController = playerWeaponHitboxLeft.GetComponent<WeaponController>();
        rightController = playerWeaponHitboxRight.GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        
        // Flip the weapon hitbox based on movement direction
        if (movement.x <= -0.01f && !rightController.isAttackingState()) 
        {
            //playerWeaponHitboxLeft.SetActive(true);
            //playerWeaponHitboxRight.SetActive(false);
            transform.localScale = new Vector3(-1, 1, 1); // Flip the player sprite to face left    
        }
        else if(movement.x >= 0.01f && !rightController.isAttackingState())
        {
            //playerWeaponHitboxLeft.SetActive(false);
            //playerWeaponHitboxRight.SetActive(true);
            transform.localScale = new Vector3(1, 1, 1); // Reset the player sprite scale to face right
        }

        // Set the "isMoving" parameter in the Animator based on movement
        if (movement.x != 0 || movement.y != 0)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

}
