using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FearEffect : MonoBehaviour
{
    /*
    [SerializeField] private GameObject PPVol;
    [SerializeField] private Transform player;
    private Grain grain;
    private PostProcessVolume postProcessVolume; 
    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
       // postProcessVolume.profile.TryGetSettings<Grain>(out grain);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        print(other.gameObject.name);
        //Destroy(other.gameObject);
        if (other.transform.tag == "FearEffect")
        {
            print(other.transform.tag);
            if ((player.position - other.transform.position).sqrMagnitude <= 20)
            {
                grain.intensity.value = 1f;
            }
            else
            {
                grain.intensity.value = 0;
            }
        }

    } */
}
