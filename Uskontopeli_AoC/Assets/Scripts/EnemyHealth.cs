using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 10;
    public float sinkSpeed = 2.5f;
    public Transform winCanvas;

    public BoxCollider boxCollider;
    bool isDead;
    bool isSinking;

	void Update ()
    {
        if (isSinking)
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if(!isDead && (currentHealth -= amount) <= 0)
            Death();
    }

    void Death()
    {
        isDead = true;
        boxCollider.isTrigger = true;
        StartSinking();

        //SceneManager.LoadScene("Level2");
        //SceneManager.UnloadScene("LoadingScene");

        
       winCanvas.gameObject.SetActive(true);
       Time.timeScale = 0;

       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
    }

    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2);
    }

}
