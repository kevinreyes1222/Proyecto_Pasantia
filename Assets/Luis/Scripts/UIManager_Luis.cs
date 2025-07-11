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
    AudioManager_Luis am;
    Sprite sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        am = AudioManager_Luis.Instance;
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
        am.musicMain.Pause();
        am.musicPause.Play();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        am.musicPause.Stop();
        am.musicMain.UnPause();
    }

    public void MuteMaster()
    {
        sprite = masterVol.GetComponent<Image>().sprite;
        if (sprite == masterOn.sprite)
        {
            sprite = masterOff.sprite;
            am.MuteMaster();
        }
        else
        {
            sprite = masterOn.sprite;
            am.UnMuteMaster();
        }
    }

    public void MuteMusic()
    {
        sprite = musicVol.GetComponent<Image>().sprite;
        if (sprite == musicOn.sprite)
        {
            sprite = musicOff.sprite;
            am.MuteMusic();
        }
        else
        {
            sprite = musicOn.sprite;
            am.UnMuteMusic();
        }
    }

    public void MuteVFX()
    {
        sprite = vfxVol.GetComponent<Image>().sprite;
        if (sprite == vfxOn.sprite)
        {
            sprite = vfxOff.sprite;
            am.MuteVFX();
        }
        else
        {
            sprite = vfxOn.sprite;
            am.UnMuteVFX();
        }
    }
}
