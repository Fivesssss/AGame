using UnityEngine;
using UnityEngine.SceneManagement;

public class CipherTextScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string cipherTextSolution = "Richard The Lionheart";

    private bool isSolved;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCipherText(string input)
    {
        if (input.ToLower() == cipherTextSolution.ToLower())
        {
            isSolved = true;
            Debug.Log("Correct Cipher Text!");
        }
        else
        {
            Debug.Log("Incorrect Cipher Text. Try again.");
        }
    }
    public bool isCipherSolved()
    {
        return isSolved;
    }
}
