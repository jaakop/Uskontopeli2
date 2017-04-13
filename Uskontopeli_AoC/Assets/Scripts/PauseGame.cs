using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
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
        if(canvas.gameObject.activeInHierarchy == false )
        {
            if (endCanvas.gameObject.activeInHierarchy == false)
            {
                if (winCanvas.gameObject.activeInHierarchy == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

        //Checks if the Esc is pressed and executes the void Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Pause();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            SceneManager.UnloadSceneAsync("Level1");
            SceneManager.LoadScene("Level2");

        }

    }
    
    public void Pause()
    {
        //Pauses the game
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Unpauses the game
        else
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
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }

}
 