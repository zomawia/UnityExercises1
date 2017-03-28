using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamage
{
    private Text myText;
    public float healthValue;
    public float armorValue;

	// for camera shake
	CameraController camControl;

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
		camControl.receivedDmg = true;
    }

    void IDamage.displayDamage(float damage)
    {

    }

    void doDestroy()
    {
        Destroy(gameObject);

        //allow to be acquire
        
    }

	void Start()
	{
		camControl = Camera.main.GetComponent<CameraController> ();
	}

	// Update is called once per frame
	void Update ()
    {
        if (healthValue <= 0)
        {            
            doDestroy();
        }
	}
}
