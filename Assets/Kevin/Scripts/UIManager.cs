using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider bgMusicVolumeSlider;

    public Toggle masterMuteToggle;
    public Toggle sfxMuteToggle;
    public Toggle bgMusicMuteToggle;

    
    private void Start()
    {
        float MasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1);
        float SfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1);
        float BgMusicVolume = PlayerPrefs.GetFloat("BgMusicVolume", 1);
        masterVolumeSlider.value = MasterVolume;
        sfxVolumeSlider.value = SfxVolume;
        bgMusicVolumeSlider.value = BgMusicVolume;

        masterMuteToggle.isOn = MasterVolume == -80;
        sfxMuteToggle.isOn = SfxVolume == -80;
        bgMusicMuteToggle.isOn = BgMusicVolume == -80;

        print("Master Volume: " + MasterVolume);        
        print("SFX Volume: " + SfxVolume);
        print("BgMusic Volume: " + BgMusicVolume);

    }
    public void VolumeMaster(float sliderValue)
    {
        AudioManager_Kevin.instance.SetVolume(sliderValue);
    }

    public void SfxVolume(float sliderValue)
    {
        AudioManager_Kevin.instance.SfxVolume(sliderValue);
    }

    public void BgMusicVolume(float sliderValue)
    {
        AudioManager_Kevin.instance.BgMusicVolume(sliderValue);
    }

    public void MuteMaster()
    {
       AudioManager_Kevin.instance.MuteMaster();
    }

    public void MuteSfx()
    {
        AudioManager_Kevin.instance.MuteSfx();
    }

    public void MuteBgMusic()
    {
        AudioManager_Kevin.instance.MuteBgMusic();
    }

}
