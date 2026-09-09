using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthUIScript : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;

    //health ui reference
    private Image healthUI;

    private float fillPerHeart = 0.2f;


    private void Start()
    {
        healthUI = GetComponent<Image>();
    }


    // add health back, since the regen pot gives max health health ui is set to 1
    public void addHealthUI() 
    {
        //this will be called after the health is filled up so the fill amount is just the current fill number
        float currentFill = fillPerHeart * playerHealth.getHealth();
        healthUI.fillAmount = currentFill;
    }

    //remove hearts, each heart is around 0.2 out of the 1 total for the fill of the sprite
    public void removeHealthUI() 
    {
        Debug.Log(playerHealth.getHealth() * fillPerHeart);
        float currentFill = fillPerHeart * playerHealth.getHealth();                    
        healthUI.fillAmount =   currentFill;
    }
}
