using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pressEnter;
    [SerializeField] private TextMeshProUGUI cipherNotSolved;
    [SerializeField] private CipherTextScript cipherTextScript;

    //bool to check if door is in range
    private bool isInDoorRange = false;

    private void Start()
    {
        //disable on start
        pressEnter.gameObject.SetActive(false);
        cipherNotSolved.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if they press enter and the cipher is not solved inform user
        if (Input.GetKeyDown(KeyCode.Return) && !cipherTextScript.isCipherSolved() && isInDoorRange)
        {
            pressEnter.gameObject.SetActive(false);
            cipherNotSolved.gameObject.SetActive(true);
            StartCoroutine(disableText());
        }
        //if they press enter and cipher is solved
        else if (Input.GetKeyDown(KeyCode.Return) && cipherTextScript.isCipherSolved() &&isInDoorRange)
        {
            Debug.Log("Main Menu");
            //add scene script
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pressEnter.gameObject.SetActive(true);
        isInDoorRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressEnter.gameObject.SetActive(false);
        cipherNotSolved.gameObject.SetActive(false);
        isInDoorRange = false;
    }

    private IEnumerator disableText() 
    {
        yield return new WaitForSeconds(5f);
        cipherNotSolved.gameObject.SetActive(false);
        //double check to ensure that this coroutine does not turn on a textmeshprougui once player has left
        if (isInDoorRange) 
        {
            pressEnter.gameObject.SetActive(true);
        }
    }
}
