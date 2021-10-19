using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_intens : MonoBehaviour
{
    private float timer;


    private void Start()
    {
        timer = 5;
    }

    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            gameObject.GetComponent<Light>().intensity = 3;
        }
        if (timer < 0) timer = 0;
        if (timer == 0)
        {
            gameObject.GetComponent<Light>().intensity = 0;
            timer = Random.Range(0, 3f);
        }
    }
}
