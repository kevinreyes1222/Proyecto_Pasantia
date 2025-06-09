using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager_Luis : MonoBehaviour
{
    private static AudioManager_Luis _instance;
    public static AudioManager_Luis Instance { get { return _instance; } }

    public AudioMixer theMixer;
    public AudioSource musicMain, musicPause, uiSource;
    public AudioClip clickSound;
    public TMP_Text masterLabel, musicLabel, vfxLabel;
    public Slider masterSlider, musicSlider, vfxSlider;
    private float lastSliderStep = -999f;
    public float lastMaster, lastMusic, lastVFX;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        if (PlayerPrefs.HasKey("MusicVol"))
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        if (PlayerPrefs.HasKey("VFXVol"))
            theMixer.SetFloat("VFXVol", PlayerPrefs.GetFloat("VFXVol"));

        float vol = 1.0f;
        theMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        theMixer.GetFloat("VFXVol", out vol);
        vfxSlider.value = vol;
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 100).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 100).ToString();
        vfxLabel.text = Mathf.RoundToInt(vfxSlider.value + 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        float steppedValue = Mathf.Round(masterSlider.value / 5f) * 5f;
        masterSlider.value = steppedValue;
        PlaySlider(masterSlider);
        masterLabel.text = (steppedValue + 100).ToString();
        theMixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        float steppedValue = Mathf.Round(musicSlider.value / 5f) * 5f;
        musicSlider.value = steppedValue;
        PlaySlider(musicSlider);
        musicLabel.text = (steppedValue + 100).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetVFXVolume()
    {
        float steppedValue = Mathf.Round(vfxSlider.value / 5f) * 5f;
        vfxSlider.value = steppedValue;
        PlaySlider(vfxSlider);
        vfxLabel.text = (steppedValue + 100).ToString();
        theMixer.SetFloat("VFXVol", vfxSlider.value);
        PlayerPrefs.SetFloat("VFXVol", vfxSlider.value);
    }

    public void MuteMaster()
    {
        lastMaster = masterSlider.value;
        theMixer.SetFloat("MasterVol", -80);
    }

    public void UnMuteMaster()
    {
        theMixer.SetFloat("MasterVol", lastMaster);
    }

    public void MuteMusic()
    {
        lastMusic = musicSlider.value;
        theMixer.SetFloat("MusicVol", -80);
    }

    public void UnMuteMusic()
    {
        theMixer.SetFloat("MusicVol", lastMusic);
    }

    public void MuteVFX()
    {
        lastVFX = vfxSlider.value;
        theMixer.SetFloat("VFXVol", -80);
    }

    public void UnMuteVFX()
    {
        theMixer.SetFloat("VFXVol", lastVFX);
    }

    public void PlayClick()
    {
        uiSource.PlayOneShot(clickSound);
    }

    public void PlaySlider(Slider slider)
    {
        float steppedValue = Mathf.Round(slider.value / 5f) * 5f;
        if (steppedValue != lastSliderStep)
        {
            lastSliderStep = steppedValue;

            PlayClick();
        }
    }
}
