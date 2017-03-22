using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamage
{
    private Text myText;
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

    void IDamage.displayDamage(float damage)
    {
        GameObject newGO = new GameObject("myTextGO");
        newGO.transform.SetParent(transform);

        myText = newGO.AddComponent<Text>();
        Font Arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        //myText.rectTransform.position = transform.position;
        myText.font = Arial;
        myText.material = Arial.material;
        myText.color = Color.red;
        myText.text = damage.ToString();
    }

    void doDestroy()
    {
        Destroy(gameObject);

        //allow to be acquire
        
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
