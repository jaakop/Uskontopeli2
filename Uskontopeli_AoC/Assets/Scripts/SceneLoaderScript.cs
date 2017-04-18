using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour {

    private bool isLoading = false;
    
    [SerializeField]
    private int scene;

    [SerializeField]
    private Text loadingText;

    [SerializeField]
    private Transform loadingCanvas;
    
    // Update is called once per frame
    void Update()
    {
        if (loadingCanvas.gameObject.activeInHierarchy == true && isLoading == false)
        {
            StartCoroutine(LoadNewScene());
            isLoading = true;
        }
        if(isLoading == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }

    }

    IEnumerator LoadNewScene()
    {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }
}
