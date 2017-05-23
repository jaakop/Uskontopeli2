using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public Transform mainCanvas;
    public Transform creditsCanvas;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCanvas.gameObject.SetActive(true);
            creditsCanvas.gameObject.SetActive(false);
        }
    }
}
