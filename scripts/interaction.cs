using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class interaction : MonoBehaviour
{
    [SerializeField] private Transform startRay;
   
    Ray _interactionRay;
    public _Gun gun;
    public PlayerHealth ph;
    public  Animator Door;
    private bool openedDoor = false;
    void Start()
    {
        ph = GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        _interactionRay = new Ray(startRay.position, startRay.forward);

        Debug.DrawRay(startRay.position, startRay.forward * 100, Color.green);
        RaycastHit hit;
       
        if (Physics.Raycast(_interactionRay, out hit))
        {
            
           
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                if (hit.transform.tag == "Ammo")
                {
                    gun.addAmmo(7);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.tag == "Armor")
                {
                    ph.FullHealth();
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.tag == "Door")
                {
                    Door = hit.transform.GetComponent<Animator>();
                    openedDoor = !openedDoor;
                   
                    Door.GetComponent<Animator>().SetBool("OpenedDoor", openedDoor);
                }
              
            }

        }
    }
}
