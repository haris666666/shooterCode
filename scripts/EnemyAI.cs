using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private Transform player;
    private NavMeshAgent agent;

    private bool enemyEnabled;
    public DamageController _damageController;

    private float damageTimer = 1f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyEnabled = false;
    }
    private void Update()
    {
        if ((agent.transform.position - player.position).sqrMagnitude <= 20f * 20f)
        {
            enemyEnabled = true;
        }
        if ((agent.transform.position - player.position).sqrMagnitude <= 2.5f * 2.5f)
        {
            anim.SetBool("Attack", true);
           // _damageController.ÑalculateDamage(player, Mathf.Abs(transform.position.z - player.position.z), Mathf.Abs(transform.position.x - player.position.x));
            if (damageTimer > 0) damageTimer -= Time.deltaTime;
            if(damageTimer <= 0)
            {
                _damageController.ÑalculateDamage(player, Mathf.Abs(transform.position.z - player.position.z), Mathf.Abs(transform.position.x - player.position.x));
                damageTimer = 1f;
            }
        }
        if ((agent.transform.position - player.position).sqrMagnitude > 2f * 2f) anim.SetBool("Attack", false);
        if ((agent.transform.position - player.position).sqrMagnitude > 30f * 30f) enemyEnabled = false;
        if (enemyEnabled == true)
        {
            agent.SetDestination(player.position);
            anim.SetBool("Walk", true);
        }


        if (transform.GetComponent<EnemyHealth>().getValue() < 70)
        {
            anim.SetBool("Run", true);
            agent.speed = 3;
        }
        //   if (enemyEnabled == false) agent.Stop();
    }
    /*public void AttackExit()
    {
        anim.SetBool("Attack", false);
    }*/
}
