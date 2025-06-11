using UnityEngine;
using UnityEngine.Audio;

public class AudioControllerRichard : MonoBehaviour
{
    
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip sfxPreviewClip;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    private bool isMasterMuted = false;
    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    private AudioSource sfxPreviewSource;

    private void Awake()
    {
        GameObject tempGO = new GameObject("SFXPreviewSource");
        sfxPreviewSource = tempGO.AddComponent<AudioSource>();
        sfxPreviewSource.outputAudioMixerGroup = sfxMixerGroup;
        sfxPreviewSource.playOnAwake = false;
        DontDestroyOnLoad(tempGO); 
    }

    public void MasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void VolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void VolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);

        if (sfxPreviewClip != null && !sfxPreviewSource.isPlaying)
        {
            sfxPreviewSource.PlayOneShot(sfxPreviewClip);
        }
    }

    //FUNCIONES PARA MUTEAR
    public void ButtonMuteMaster()
    {
        isMasterMuted = !isMasterMuted;
        audioMixer.SetFloat("MasterVolume", isMasterMuted ? -80f : 0f);
    }

    public void ButtonMuteMusic()
    {
        isMusicMuted = !isMusicMuted;
        audioMixer.SetFloat("MusicVolume", isMusicMuted ? -80f : 0f);
    }

    public void ButtonMuteSFX()
    {
        isSFXMuted = !isSFXMuted;
        audioMixer.SetFloat("SFXVolume", isSFXMuted ? -80f : 0f);
    }
    
    /*
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip sfxPreviewClip;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    private bool isMasterMuted = false;
    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    private AudioSource sfxPreviewSource;

    private void Awake()
    {
        // Crear fuente de audio dinámica para preview de SFX
        GameObject tempGO = new GameObject("SFXPreviewSource");
        sfxPreviewSource = tempGO.AddComponent<AudioSource>();
        sfxPreviewSource.outputAudioMixerGroup = sfxMixerGroup;
        sfxPreviewSource.playOnAwake = false;
        DontDestroyOnLoad(tempGO);
    }

    private void Start()
    {
        // Cargar valores guardados o usar 1.0f por defecto
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        bool muteMaster = PlayerPrefs.GetInt("MuteMaster", 0) == 1;
        bool muteMusic = PlayerPrefs.GetInt("MuteMusic", 0) == 1;
        bool muteSFX = PlayerPrefs.GetInt("MuteSFX", 0) == 1;

        MasterVolume(master);
        VolumeMusic(music);
        VolumeSFX(sfx);

        if (muteMaster) ButtonMuteMaster();
        if (muteMusic) ButtonMuteMusic();
        if (muteSFX) ButtonMuteSFX();
    }

    public void MasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void VolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void VolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);

        // Reproducir clip de prueba
        if (sfxPreviewClip != null && !sfxPreviewSource.isPlaying)
        {
            sfxPreviewSource.PlayOneShot(sfxPreviewClip);
        }
    }

    // FUNCIONES PARA MUTEAR
    public void ButtonMuteMaster()
    {
        isMasterMuted = !isMasterMuted;
        float baseVol = PlayerPrefs.GetFloat("MasterVolume", 1f);
        audioMixer.SetFloat("MasterVolume", isMasterMuted ? -80f : Mathf.Log10(baseVol) * 20);
        PlayerPrefs.SetInt("MuteMaster", isMasterMuted ? 1 : 0);
    }

    public void ButtonMuteMusic()
    {
        isMusicMuted = !isMusicMuted;
        float baseVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioMixer.SetFloat("MusicVolume", isMusicMuted ? -80f : Mathf.Log10(baseVol) * 20);
        PlayerPrefs.SetInt("MuteMusic", isMusicMuted ? 1 : 0);
    }

    public void ButtonMuteSFX()
    {
        isSFXMuted = !isSFXMuted;
        float baseVol = PlayerPrefs.GetFloat("SFXVolume", 1f);
        audioMixer.SetFloat("SFXVolume", isSFXMuted ? -80f : Mathf.Log10(baseVol) * 20);
        PlayerPrefs.SetInt("MuteSFX", isSFXMuted ? 1 : 0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
   */
    
}
