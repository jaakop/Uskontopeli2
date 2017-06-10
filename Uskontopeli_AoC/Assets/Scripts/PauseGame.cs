using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;
    public Transform endCanvas;
    public Transform winCanvas;
    
    private void Start()
    {
        //Set the cursor ready
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update ()
    {
        //Reveals the cursor
        if(!canvas.gameObject.activeInHierarchy && 
            !endCanvas.gameObject.activeInHierarchy && 
             !winCanvas.gameObject.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //Checks if the Esc is pressed and executes the void Pause
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

    }
    
    public void Pause()
    {
        // Pauses the game
        if (!canvas.gameObject.activeInHierarchy)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else // Resumes the game
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    //Leaves the game
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

    public void ReStart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);       
    }
}
 