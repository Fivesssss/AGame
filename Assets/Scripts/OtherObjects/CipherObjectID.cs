using UnityEngine;

public class CipherObjectID : MonoBehaviour
{
    public int cipherID; //between 1 and 4

    public void SetCipherID(int id)
    {
        cipherID = id;
    }

    public int GetCipherID()
    {
        return cipherID;
    }
}
