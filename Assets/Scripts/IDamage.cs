using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamage
{
    float EstimatedDamageTaken(float damage);
    void TakeDamage(float damage);

    void displayDamage(float damage);
}
