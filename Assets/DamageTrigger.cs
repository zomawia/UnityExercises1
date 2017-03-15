using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour {

    public float damageOnContact = 5.0f;
    public float damageOverTime = 5.0f;

    private List<IDamage> occupants = new List<IDamage>();

    private void Update()
    {
        for (int i = 0; i < occupants.Count; ++i)
        {
            occupants[i].TakeDamage(damageOverTime * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage target = other.gameObject.GetComponent<IDamage>();

        if (target == null) { return; }

        target.TakeDamage(damageOnContact);

        occupants.Add(target);
    }

    private void OnTriggerExit(Collider other)
    {
        IDamage target = other.gameObject.GetComponent<IDamage>();

        if (target == null) { return; }

        occupants.Remove(target);
    }
}
