using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    
   [SerializeField] private int value;
   [SerializeField] private Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public int getValue()
    {
        return value;
    }

    public void AddDamage(int damage)
    {
        value -= damage;
       // print(damage);
    }
     
    void Update()
    {
        if(value <= 0)
        {
            Anim.SetBool("Death", true);
            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<NavMeshAgent>().enabled = false;
            transform.GetComponent<EnemyAI>().enabled = false;
            //Destroy(gameObject);
        }

    }
}
