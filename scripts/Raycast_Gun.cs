using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast_Gun : MonoBehaviour
{
    Animator Anim;

    [SerializeField] private Transform startRay;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pointer;
    [SerializeField] private ParticleSystem ps;
    
    public DamageController _damageController;

    private bool aimGun = false;

    private float timerGun = 3f;

    Ray GunRay;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        ps.GetComponent<Light>().intensity = 0;
        ps.Stop();
    }

    void Update()
    {
        GunRay = new Ray(startRay.position, startRay.forward);
        Debug.DrawRay(startRay.position, startRay.forward * 20, Color.red);

        if (timerGun > 0)
        {
            timerGun -= Time.deltaTime;
            ps.Stop();
            ps.GetComponent<Light>().intensity = 0;
        }

        RaycastHit hit;
        if(Physics.Raycast(GunRay, out hit))
        {
            pointer.position = hit.point;

            

            if (Mouse.current.leftButton.wasPressedThisFrame && timerGun <= 0)
            {
                ps.Play();
                ps.GetComponent<Light>().intensity = 2f;
                if (hit.transform.tag == "Enemy")
                {
                    
                    _damageController.ÑalculateDamage(hit, Mathf.Abs(pointer.position.z - player.position.z), Mathf.Abs(pointer.position.x - player.position.x));

                }
                Anim.SetBool("Shoot", true);
                timerGun = 3f;
                
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                aimGun = !aimGun;
                Anim.SetBool("Aim", aimGun);
            } 


            if (hit.transform.tag != "Enemy")
            {
                if ((pointer.position - player.position).sqrMagnitude <= 2.75f * 2.75f)
                {
                    Anim.SetBool("Ray", true);
                }

                else
                {
                     Anim.SetBool("Ray", false);
                }
            }
        }

        

    }
    public void AnimExitTime()
    {
        Anim.SetBool("Shoot", false);
        ps.Stop();
    }
}
