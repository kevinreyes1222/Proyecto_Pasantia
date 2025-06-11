using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
//using static Unity.VisualScripting.Member;


public class AudioManager : MonoBehaviour
{
     bool ActivarMusicaDinamica; //esto es la musica dinamica jodida al momento

    public bool ActivarMusicaDePeleaa;
    public bool IniciarMusicaDeFondo;
    public bool PararMusicaDeFondoB;
    public int clipToTest;

    public GameObject InventoryCanvas;
    public AudioSource Source0;
    
    
    public bool testMixerMute = false;
    public bool availableToTalk = false;
   
    public static AudioManager instance;
    
    
    public Sounds[] sounds;
    public Sounds[] VFXsounds;
    public Sounds[] backGround_MusicSounds;
    public AudioSource[] fuentes;

    public AudioMixerGroup Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;

    public static float cliplength = 0;
    public float wait1 = 0;
    public float wait2 = 0;
    public float wait3 = 0;
    public float fadeDuration = 0.5f; // Duración del fade en segundos

    public int x0;
   public int x1;
   public int x2;
    
    
    public AudioSource currentClip;
    
  //  public AudioMixer mixer;
    //public AudioMixerGroup voices;
   // public AudioMixerGroup SFX;
   // public AudioMixerGroup backGround_Music;

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";
    public const string VOICE_KEY = "voiceVolume";

    public static float musicVolume;
    public static float sfxVolume;
    public static float voiceVolume;

    int woodBreak;
    public AudioClip[] STEPS; 


    public void Update()
    {
        
    }
    private void Awake()
    {
        
       
        
        if (instance == null)
        {
            instance = this;

        }
        
        foreach (Sounds s in VFXsounds)
        {

             /*s.source = gameObject.AddComponent<AudioSource>();
             s.source.clip = s.Clip;

             s.source.volume = s.Volume;
             s.source.pitch = s.Pitch;
            // s.source.outputAudioMixerGroup = voices;
             s.source.ignoreListenerPause = true;
            // s.source.outputAudioMixerGroup = SFX;*/
            

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.ignoreListenerPause = true;
            s.source.outputAudioMixerGroup = SFX;

        }

        foreach (Sounds s in backGround_MusicSounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.outputAudioMixerGroup = Music;
            s.source.loop = true;

        }
       // StartCoroutine(FadeInWarriorMusic(5));
       // StartCoroutine(DinamicMusicWarrior());
    }



    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }
    public void PlayVFX(string name)
    {
        Sounds s = Array.Find(VFXsounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayMusicBackGround(string name)
    {
        Sounds s = Array.Find(backGround_MusicSounds, sound => sound.name == name);
        s.source.Play();
    }

    public void playArmorHit()
    {
        StartCoroutine(armorHitSounddelayed());
       
    }

    public IEnumerator armorHitSounddelayed()
    {
        yield return new WaitForSeconds(0.2f);

        AudioManager.instance.PlayVFX("armorHit");
        print("se reprodujo el armor hit");
    }

    public void playWoodBreak()
    {
        StartCoroutine(WoodBreakSounddelayed());

    }

    public IEnumerator WoodBreakSounddelayed()
    {
        yield return new WaitForSeconds(0.2f);
        woodBreak= UnityEngine.Random.Range(1, 4);
        print("se escogio el sonido de destruccion " + woodBreak);
        if (woodBreak == 1)
        {
            AudioManager.instance.PlayVFX("woodBreak1");
        }

        if (woodBreak == 2)
        {
            AudioManager.instance.PlayVFX("woodBreak2");
        }

        if (woodBreak == 3)
        {
            AudioManager.instance.PlayVFX("woodBreak3");
        }
        
    }



    public IEnumerator DinamicMusicWarrior() // SISTEMA DE MUSICA DE COMBATE DINAMICO
    {
        if (ActivarMusicaDinamica == true)
        {
            // StartCoroutine(FadeOutWarriorMusic(10));
            print("el audio LLEGPOOOOO AQUIIII******************");
            if (x0 == 0)
            {
                Source0.clip = backGround_MusicSounds[1].Clip;
                Source0.Play();
                //  PlayMusicBackGround("WarriorIntro");
                yield return new WaitForSeconds(24.55f);

                x0 = UnityEngine.Random.Range(1, 5);
            }


            if (x0 == 1)
            {
                Source0.clip = backGround_MusicSounds[2].Clip;
                Source0.Play();
                yield return new WaitForSeconds(16);
                x0 = UnityEngine.Random.Range(1, 5);
                StartCoroutine(DinamicMusicWarrior());
            }
            if (x0 == 2)
            {
                Source0.clip = backGround_MusicSounds[3].Clip;
                Source0.Play();
                yield return new WaitForSeconds(16);
                x0 = UnityEngine.Random.Range(1, 5);
                StartCoroutine(DinamicMusicWarrior());
            }
            if (x0 == 3)
            {
                Source0.clip = backGround_MusicSounds[4].Clip;
                Source0.Play();
                yield return new WaitForSeconds(16);
                x0 = UnityEngine.Random.Range(1, 5);
                StartCoroutine(DinamicMusicWarrior());
            }
            if (x0 == 4)
            {
                Source0.clip = backGround_MusicSounds[5].Clip;
                Source0.Play();
                yield return new WaitForSeconds(16);
                x0 = UnityEngine.Random.Range(1, 5);
                StartCoroutine(DinamicMusicWarrior());
            }
        }

        
    }


    

    IEnumerator FadeInWarriorMusic(float fadeDuration)
    {
        if (ActivarMusicaDinamica == true)
        {
            if (x1 == 0)
            {
                StartCoroutine(DinamicMusicWarrior());
                if (Source0.isPlaying == true)
                {
                    print("el audio se esta reproduciendo");
                }
                else
                {
                    print("el audio NOOOO se esta reproduciendo");
                    Source0.UnPause();
                }
                yield return new WaitForSeconds(0);
                float startVolume = 1;

                while (Source0.volume < 0.4f)
                {

                    Source0.volume += startVolume * Time.deltaTime / fadeDuration;
                    yield return null;
                }

                // Ensure the volume is set to 0 to avoid any potential rounding errors
                // Source0.volume = 0f;

                // Optionally, you can stop the audio playback
                // Source0.Stop();
                x1++;
            }
        }

        

    }

    public void activateFadeIn()
    {
        StartCoroutine(FadeInWarriorMusic(7));
    }

    


    //nuevo sistema de musica de pelea dinamica este la inicia
   

    IEnumerator FadeInBackGroundMusicMusic(float fadeDuration)
    {
        if (ActivarMusicaDePeleaa == true)
        {
            if (x2 == 0)
            {

                Source0.volume=0; 
                Source0.Play(); 
                Source0.loop = true;    
                 yield return new WaitForSeconds(0);
                float startVolume = 1;

                while (Source0.volume < 0.9f) // lo que estab a antes era  while (Source0.volume < 0.08f)
                {

                    Source0.volume += startVolume * Time.deltaTime / fadeDuration;
                    print("se esta subiendo el audio aquiiiiiiiiiiiiiiiiiiii");
                    yield return null;
                }

                // Ensure the volume is set to 0 to avoid any potential rounding errors
                // Source0.volume = 0f;

                // Optionally, you can stop the audio playback
                // Source0.Stop();
                x2++;
                print(x2);
            }
        }
    }


    //nuevo sistema de musica de pelea dinamica este la detiene
    public void PararMusicaDeFondo(float fadeDuration)
    {
        StartCoroutine(FadeOutBackGroundMusicMusic(fadeDuration));
    }

    IEnumerator FadeOutBackGroundMusicMusic(float fadeDuration)
    {
        if (ActivarMusicaDePeleaa == true)
        {
            if (x2 >= 1)
            {

                
                yield return new WaitForSeconds(0);
                float startVolume = 1;
                Source0.loop = false;
                while (Source0.volume > 0f)
                {

                    Source0.volume -= startVolume * Time.deltaTime / fadeDuration;
                    yield return null;
                }

                // Ensure the volume is set to 0 to avoid any potential rounding errors
                // Source0.volume = 0f;

                // Optionally, you can stop the audio playback
                // Source0.Stop();
                Source0.volume = 0;
                Source0.Stop();
                ActivarMusicaDePeleaa = false;
                x2=0;
                print(x2);
            }
        }
    }
    public void StopMusicByName(string name)
    {
        // Busca el sonido en el array de música de fondo por nombre
        Sounds s = Array.Find(backGround_MusicSounds, sound => sound.name == name);

        // Verifica si se encontró el sonido y si está reproduciéndose antes de detenerlo
        if (s != null && s.source.isPlaying)
        {
            s.source.Stop();
            Debug.Log($"La música '{name}' se ha detenido.");
        }
        else
        {
            Debug.LogWarning($"No se encontró o no se está reproduciendo la música '{name}'.");
        }
    }

    public void InventorySound()
    {
        if (InventoryCanvas.activeSelf == true)
        {
            PlayVFX("OpenInventory");
        }
        else
        {
            PlayVFX("ClosingInventory");
        }
    }

    #region fade-SoundCodes

    [Obsolete]
    public void FadeOutAllSoundsW()
    {
        // Obtenemos todos los AudioSource en la escena
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Inicia el fade out para cada AudioSource
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying)
            {
                StartCoroutine(FadeOut(audioSource, fadeDuration));
            }
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        // Reduce gradualmente el volumen
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        // Pausa el audio y restablece el volumen original
        audioSource.Pause();
        audioSource.volume = startVolume;
    }

    [System.Obsolete]
    public void FadeInAllSounds()
    {
        // Obtenemos todos los AudioSource en la escena
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Inicia el fade in para cada AudioSource que estaba pausado
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (!audioSource.isPlaying)
            {
                StartCoroutine(FadeIn(audioSource, fadeDuration));
            }
        }
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.UnPause();
        float targetVolume = 1f; // Volumen objetivo al reanudar (ajusta según tu configuración)

        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
    #endregion
}
