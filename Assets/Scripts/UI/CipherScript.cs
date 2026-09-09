using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Constraints;

public class CipherScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] ciphers;

    //current cipher level, starting at 00 where none of the cipher is unlocked
    [SerializeField] private int currentCipherLevel = 0;

    private void Start()
    {
        for(int i = 0; i < ciphers.Length; i++)
        {
            ciphers[i].gameObject.SetActive(false);
        }
        ciphers[0].gameObject.SetActive(true); //unlock the first cipher by default
    }

    //to be called from player inventory when it collectcs a cipher unlock item
    public void unlockNewCipherLevel(GameObject cipherUnlockItem) 
    {
        //unlock the respective cipher text based on the cipher unlock item collected
        ciphers[cipherUnlockItem.GetComponent<CipherObjectID>().GetCipherID()].gameObject.SetActive(true);
        for (int i = 0; i < ciphers.Length; i++) {
            if (ciphers[i].enabled)
            {
                Debug.Log("Cipher " + (i + 1) + " enabled: " );
            }
        }
        Destroy(cipherUnlockItem); //destroy the cipher unlock item after unlocking the cipher
    }

}
