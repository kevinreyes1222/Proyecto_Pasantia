using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject canvaPanel;
    bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        isOpen = !isOpen;
        canvaPanel.SetActive(isOpen);

        if (isOpen)
        {
            Time.timeScale = 0f; // Pause the game

            Cursor.visible = true; // Show the cursor
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        }
    }
}
