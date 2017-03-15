using UnityEngine;

public class PauseGame : MonoBehaviour {
    public Transform canvas;

    private void Start()
    {
        //Set the cursor ready
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update ()
    {
        //Reveals the cursor
        if(canvas.gameObject.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //Checks if the Esc is pressed and executes the void Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Pause();
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

}
 