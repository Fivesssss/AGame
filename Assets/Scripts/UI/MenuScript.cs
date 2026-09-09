using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    private void Start() 
    {
        menuScreen.SetActive(false); //this shhould onyl be enabled by the player
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            menuScreen.SetActive(!menuScreen.activeSelf); //This will set the menu to the Opposite of what it currently is
        }
    }
}
