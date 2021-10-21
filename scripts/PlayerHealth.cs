using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float value;
    private Vignette vignette;
    [SerializeField] GameObject PPvol;
    PostProcessVolume pps;
    private void Start()
    {
        pps = PPvol.GetComponent<PostProcessVolume>();
        pps.profile.TryGetSettings<Vignette>(out vignette);
    }

    public void AddDamage(int damage)
    {
        value -= damage;
        print(damage + "hero");
    }
    void FixedUpdate()
    {
        vignetteValue();
        if (value <= 0)
        {
            Application.LoadLevel("SampleScene");
            print("You death");
        }

    }
    void vignetteValue()
    {
        if (value == 0)
        {
            vignette.intensity.value = 1f;
        }
        else
        {
            vignette.intensity.value = (1 - (value / 100)) / 2;
        }

    }
}

