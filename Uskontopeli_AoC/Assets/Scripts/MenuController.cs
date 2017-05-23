using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Transform loadingCanvas;
    public Transform mainCanvas;
    public Transform creditsCanvas;

    public void NewGame()
    {
        loadingCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

    public void Credits()
    {
        creditsCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }
}
