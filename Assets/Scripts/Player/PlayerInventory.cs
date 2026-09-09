using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] CipherScript cipherScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("cipherUnlockItem") && this.CompareTag("Player"))
        {
            Debug.Log("Player has collided with a cipher unlock item.");
            Debug.Log("Cipher ID: " + collision.gameObject.GetComponent<CipherObjectID>().GetCipherID());
            cipherScript.unlockNewCipherLevel(collision.gameObject);
        }
    }
}
