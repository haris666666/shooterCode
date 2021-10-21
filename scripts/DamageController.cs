using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
   [SerializeField] private int Damage = 10;
    public void ÑalculateDamage(RaycastHit hit, float distanceZ, float distanceX)
    {
       // print(hit.transform.position.x);

         if(distanceZ <= 15 && distanceX <= 15)
         {
             hit.transform.GetComponent<EnemyHealth>().AddDamage(Damage * 3);
         }
         if (distanceZ <= 20 && distanceX <= 20)
         {
             hit.transform.GetComponent<EnemyHealth>().AddDamage(Damage * 2);
         }
         else
         {
             hit.transform.GetComponent<EnemyHealth>().AddDamage(Damage / 2);
         } 
    }
    public void ÑalculateDamage(Transform player, float distanceZ, float distanceX)
    {
        if(distanceZ <= 5 && distanceX <= 5)
        {
            player.GetComponent<PlayerHealth>().AddDamage(25);
        }
    }
}
