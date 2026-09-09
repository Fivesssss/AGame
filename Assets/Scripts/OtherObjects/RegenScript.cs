using UnityEngine;

public class RegenScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerHealth>().healPlayer(5);
            Destroy(gameObject);
        }
    }
}
