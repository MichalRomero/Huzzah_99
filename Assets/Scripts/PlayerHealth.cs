using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text HealthText;
    public Animator healthTextAnim;

    private void Start()
    {
        //used for health UI
        HealthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

    //amount allows to pass in healing or damage amounts
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        //when player takes damage, play TextUpdate Animation
        healthTextAnim.Play("TextUpdate");

        //updates health UI
        HealthText.text = "HP: " + currentHealth + "/" + maxHealth;

        //if characters health is below zero, die. (right now this turns off the player obj)
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
