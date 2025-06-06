using UnityEngine;
using UnityEngine.UI;

public class UIManager_Luis : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;
    public Button masterVol;
    public SpriteRenderer masterOn, masterOff;
    public Button musicVol;
    public SpriteRenderer musicOn, musicOff;
    public Button vfxVol;
    public SpriteRenderer vfxOn, vfxOff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        AudioManager_Luis.Instance.musicMain.Pause();
        AudioManager_Luis.Instance.musicPause.Play();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        AudioManager_Luis.Instance.musicPause.Stop();
        AudioManager_Luis.Instance.musicMain.UnPause();
    }

    public void MuteMaster()
    {
        if(masterVol.GetComponent<Image>().sprite == masterOn.sprite)
        {
            masterVol.GetComponent<Image>().sprite = masterOff.sprite;
            AudioManager_Luis.Instance.MuteMaster();
        }
        else
        {
            masterVol.GetComponent<Image>().sprite = masterOn.sprite;
            AudioManager_Luis.Instance.UnMuteMaster();
        }
    }

    public void MuteMusic()
    {
        if (musicVol.GetComponent<Image>().sprite == musicOn.sprite)
        {
            musicVol.GetComponent<Image>().sprite = musicOff.sprite;
            AudioManager_Luis.Instance.MuteMusic();
        }
        else
        {
            musicVol.GetComponent<Image>().sprite = musicOn.sprite;
            AudioManager_Luis.Instance.UnMuteMusic();
        }
    }

    public void MuteVFX()
    {
        if (vfxVol.GetComponent<Image>().sprite == vfxOn.sprite)
        {
            vfxVol.GetComponent<Image>().sprite = vfxOff.sprite;
            AudioManager_Luis.Instance.MuteVFX();
        }
        else
        {
            vfxVol.GetComponent<Image>().sprite = vfxOn.sprite;
            AudioManager_Luis.Instance.UnMuteVFX();
        }
    }
}
