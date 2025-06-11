using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager_Kevin : MonoBehaviour
{
    public static AudioManager_Kevin instance;

    [SerializeField] private AudioMixer myAudioMixer;
    
    public bool isMasterMuted = false;
    public bool isBgMusicMuted = false;
    public bool isSfxMuted = false;

    public float lastVolumeMaster = 0;
    public float lastVolumeBgMusic = 0;
    public float lastVolumeSfx = 0;


    private void Awake()
    {
        if(instance != null) Destroy(gameObject);
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        myAudioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume",0)) * 20);
        myAudioMixer.SetFloat("SfxVolume", Mathf.Log10(PlayerPrefs.GetFloat("SfxVolume", 0)) * 20);
        myAudioMixer.SetFloat("BgMusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("BgMusicVolume", 0)) * 20);
        


    }
    public void SetVolume(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        myAudioMixer.SetFloat("MasterVolume", volume);
        lastVolumeMaster = volume;
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);

    }

    public void SfxVolume (float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        myAudioMixer.SetFloat("SfxVolume", volume);
        lastVolumeSfx = volume;
        PlayerPrefs.SetFloat("SfxVolume", sliderValue);

    }
    public void BgMusicVolume(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        myAudioMixer.SetFloat("BgMusicVolume", volume);
        lastVolumeBgMusic = volume;
        PlayerPrefs.SetFloat("BgMusicVolume", sliderValue);

    }

    public void MuteMaster()
    {
        isMasterMuted = !isMasterMuted;
        myAudioMixer.SetFloat("MasterVolume", isMasterMuted ? -80f : lastVolumeMaster);
        PlayerPrefs.SetFloat("MasterVolume", isMasterMuted ? -80f : lastVolumeMaster);
    }

    public void MuteSfx()
    {
        isSfxMuted = !isSfxMuted;
        myAudioMixer.SetFloat("SfxVolume", isSfxMuted ? -80f : lastVolumeSfx);
        PlayerPrefs.SetFloat("SfxVolume", isSfxMuted ? -80f : lastVolumeSfx);
    }

    public void MuteBgMusic()
    {
        isBgMusicMuted = !isBgMusicMuted;
        myAudioMixer.SetFloat("BgMusicVolume", isBgMusicMuted ? -80f : lastVolumeBgMusic);
        PlayerPrefs.SetFloat("BgMusicVolume", isBgMusicMuted ? -80f : lastVolumeBgMusic);

    }


}
