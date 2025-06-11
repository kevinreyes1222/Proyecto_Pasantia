using UnityEngine;

public class PauseManager : MonoBehaviour
{ 
    /*
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;

    private bool isPaused = false;

    void Update()
    {
        // Usamos GetKeyUp para que solo se dispare al SOLTAR la tecla.
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // 1) Si estamos en el menú de opciones, volvemos al de pausa
            if (optionsMenuCanvas.activeSelf)
            {
                optionsMenuCanvas.SetActive(false);
                pauseMenuCanvas.SetActive(true);
            }
            // 2) Si ya estamos pausados, reanudamos
            else if (isPaused)
            {
                ResumeGame();
            }
            // 3) Si no estamos pausados, pausamos
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(false);
    }

    public void GoToOptions()
    {
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        optionsMenuCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }
    */

    
      [Header("UI Canvases")]
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;
    
    [Header("Background Music")]
    [SerializeField] private AudioSource backgroundMusicSource;  // <- Referencia al AudioSource de la música

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (optionsMenuCanvas.activeSelf)
            {
                optionsMenuCanvas.SetActive(false);
                pauseMenuCanvas.SetActive(true);
            }
            else if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false);

        // Pausar música de fondo
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
            backgroundMusicSource.Pause();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(false);

        // Reanudar música de fondo
        if (backgroundMusicSource != null)
            backgroundMusicSource.UnPause();
    }

    public void GoToOptions()
    {
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        optionsMenuCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

     
}
