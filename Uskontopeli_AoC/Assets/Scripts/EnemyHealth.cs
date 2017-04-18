using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 10;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public Transform winCanvas;

    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

        currentHealth = startingHealth;
    }

	void Update ()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        boxCollider.isTrigger = true;

  
        //SceneManager.LoadScene("Level2");
        //SceneManager.UnloadScene("LoadingScene");
        

       winCanvas.gameObject.SetActive(true);
       Time.timeScale = 1;
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
