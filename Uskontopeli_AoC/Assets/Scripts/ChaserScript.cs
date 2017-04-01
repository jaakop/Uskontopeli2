using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour {


    [SerializeField]
    public int health = 10;

    [SerializeField]
    public int damage = 1;

    [SerializeField]
    public float attackSpeed = 1f;

    public float attackDelay = 2f;

    public float attackTimer = 0f;

    public Transform endCanvas;

    public Transform player;

    public float walkingDistance = 10;

    public float attackDistance = 0.1f;

    public float smoothTime = 10f;

    private Vector3 smoothVelocity = Vector3.zero;

	void Start () {
		
	}


	void Update () {
        attackTimer -= Time.deltaTime;
        transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance < walkingDistance && distance > attackDistance)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
        else if(distance < attackDistance)
        {
            if (health > 0)
            {
                if (attackTimer < attackSpeed)
                {
                    attackTimer = attackDelay;
                    health -= damage;
                    
                }
            }
            else
            {
                EndGame();
            }
        }
	}

    void EndGame()
    {

        endCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
