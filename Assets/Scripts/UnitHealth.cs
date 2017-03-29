using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour, IDamage
{
    private Text myText;
    public float healthValue;
    public float armorValue;
    public Color[] normalColor;
    public Color collideColor = Color.red;
    Renderer[] oldColors;
    Renderer[] objs;

    public GameObject ExplosionVFX;

    public UnitHealth() : this(100, 0) { }

    public UnitHealth(float startHealth) : this(startHealth, 0) { }

    public UnitHealth(float startHealth, float startArmor)
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
        //for (int i = 0; i < objs.Length; ++i)
        //{
        //    objs[i].material.color = collideColor;            
        //}

        //for (int i = 0; i < objs.Length; ++i)
        //{
        //    objs[i].material.color = oldColors[i].material.color;
        //}
    }

    void Explode()
    {
        Instantiate(ExplosionVFX, transform.position, transform.rotation);
        ExplosionVFX.transform.parent = transform;
        //Destroy(gameObject, exp.main.duration);
    }

    void doDestroy()
    {
        //if (GetComponent<EnemyShooter>())
        //    Destroy(GetComponent<EnemyShooter>());
        //if (GetComponent<_BaseAIController>())
        //    Destroy(GetComponent<_BaseAIController>());
        //if (GetComponent<EnemyCharger>())
        //    Destroy(GetComponent<EnemyCharger>());

        foreach (Transform obj in transform)
        {
            obj.gameObject.AddComponent<Rigidbody>();
            obj.gameObject.AddComponent<UnitProperties>();
            obj.gameObject.tag = "Unit";
        }

        transform.DetachChildren();
        DestroyObject(gameObject);
        //allow to be acquire
    }

    void Start()
    {        
        objs = oldColors = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (healthValue <= 0)
        {
            Explode();
            doDestroy();
        }
    }
}
