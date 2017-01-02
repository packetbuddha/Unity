using UnityEngine;

using UnityEngine.Networking;
using System.Collections.Generic;


public class Player : NetworkBehaviour {

    [SyncVar]
    private int currentHealth;
    private bool isDead = false;

    private Dictionary<string, int> playerDefaults = new Dictionary<string, int>();

    private void Start()
    {
        playerDefaults.Add("maxHealth", 100);
        SetDefaults();
    }

    private void SetDefaults ()
    {
        currentHealth = playerDefaults["maxHealth"];
    }

    public void TakeDamage (int _damage)
    {
        currentHealth -= _damage;
        Debug.Log("Player " + transform.name + "has " + currentHealth + " health");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die ()
    {
        isDead = true;
    }
}
