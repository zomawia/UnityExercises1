using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamage
{
    public float healthValue;
    public float armorValue;

    public PlayerHealth() : this(100, 0) { }

    public PlayerHealth(float startHealth) : this(startHealth, 0) { }

    public PlayerHealth(float startHealth, float startArmor)
    {
        healthValue = startHealth;
        armorValue = startArmor;
    }

    float IDamage.EstimatedDamageTaken(float damageDealt)
    {
        if (armorValue <= 0) return damageDealt;
        return (damageDealt / armorValue);
    }

    void IDamage.TakeDamage(float damageDealt)
    {
        IDamage dmg = this;
        healthValue -= dmg.EstimatedDamageTaken(damageDealt);
    }

    void doDestroy()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        if (healthValue <= 0)
        {
            --Spawner.livingSpawns;
            doDestroy();
        }
	}
}
