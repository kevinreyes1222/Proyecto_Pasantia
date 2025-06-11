using UnityEngine;


using System.Collections;
using UnityEngine.Playables;


using System.Linq;
using UnityEngine.Video;


public class Helper : MonoBehaviour
{

    public AudioSource audioSource;
    int random;

    public void stepSound()
    {
        random = Random.Range(1, 6);

        if (random == 1)
        {

            audioSource.clip = AudioManager.instance.STEPS[0];
            audioSource.Play();
        }

        if (random == 2)
        {
            audioSource.clip = AudioManager.instance.STEPS[1];
            audioSource.Play();
        }

        if (random == 3)
        {
            audioSource.clip = AudioManager.instance.STEPS[2];
            audioSource.Play();
        }

        if (random == 4)
        {
            audioSource.clip = AudioManager.instance.STEPS[3];
            audioSource.Play();
        }

        if (random == 5)
        {
            audioSource.clip = AudioManager.instance.STEPS[4];
            audioSource.Play();
        }

       

    }


    [ContextMenu("testSFX")]
    public void probarSonido(string sonido)
    {
        AudioManager.instance.PlayVFX(sonido);
    }


}
