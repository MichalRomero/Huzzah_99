using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        //if characters health is below zero, die. (right njow this turns off the player obj)
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
