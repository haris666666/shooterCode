using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FearEffect : MonoBehaviour
{
    private Grain grain;
    private PostProcessVolume postProcessVolume; 
    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings<Grain>(out grain);
    }


    private void Update()
    {


        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Enemy")
            {
                if((transform.position- other.transform.position).sqrMagnitude <= 20)
                {
                    grain.intensity.value = 1f;
                }
                else
                {
                    grain.intensity.value = 0;
                }
            }
        }
    }
}
