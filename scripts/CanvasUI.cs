using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Text ammo;
    public Image recharge;
    private float rechargeValue;
    [SerializeField] private _Gun gun;
    [SerializeField] private GameObject menu;
    private bool menuEnabled = false;
    private float timerRecharge = 3f;
    Cursor cursor;

    private void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (timerRecharge - Time.deltaTime < 0) timerRecharge = 0;
        timerRecharge -= Time.deltaTime;
        ammo.text = gun.getAmmo().ToString();
        if (Mouse.current.leftButton.wasPressedThisFrame && recharge.fillAmount == 1 && menuEnabled == false)
        {
            recharge.fillAmount = 0;
            timerRecharge = 3f;
        }
       if(gun.getAimGun() == false) recharge.fillAmount += 0.33f * Time.deltaTime;
       if (gun.getAimGun() == true) recharge.fillAmount += 0.5f * Time.deltaTime;


        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
           // Cursor.visible = true;
            // Time.timeScale = 0;
            menuEnabled = !menuEnabled;
            Cursor.visible = menuEnabled;
            
            menu.SetActive(menuEnabled);
            if (menuEnabled == true)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                gun.gameObject.SetActive(false);
            }
            else
            {
                gun.gameObject.SetActive(true);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
           // menuEnabled = true;
        }

        /*if (Keyboard.current.escapeKey.wasPressedThisFrame && menuEnabled == false)
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            menu.SetActive(false);
            menuEnabled = false;
        } */
    }

   public void Exit()
    {
        Application.Quit();
    }
}
