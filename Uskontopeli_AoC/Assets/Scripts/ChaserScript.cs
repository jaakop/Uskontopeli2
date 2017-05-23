using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    [SerializeField]
    public int health = 10;

    [SerializeField]
    public float damage = 10f;

    [SerializeField]
    public float attackSpeed = 1f;

    public float attackDelay = 2f;

    public float attackTimer = 0f;

    public Transform winCanvas;

    public Transform player;

    public Transform playerHealth;

    public float walkingDistance = 10;

    public float attackDistance = 0.1f;

    public float smoothTime = 10f;

    private Vector3 smoothVelocity = Vector3.zero;

    public bool isDamaging;

	void Update ()
    {
        attackTimer -= Time.deltaTime;
        transform.LookAt(player);
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= walkingDistance)
        {
            if (distance > attackDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
            }
            else if (health > 0)
            {
                if (attackTimer < attackSpeed)
                {
                    PlayerController.Player.TakeDamage(damage);
                    attackTimer = attackDelay;
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
        winCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
