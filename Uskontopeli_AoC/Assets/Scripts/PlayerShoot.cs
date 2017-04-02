using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    private bool loaded = true;

    private float reloadTime = 0;

    [SerializeField]
    private float countDown;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private LayerMask shootableMask;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private float duration = 1f;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    public int damage = 1;


    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No camera referenced");
            this.enabled = false;
        }

    }

    void Update()
    {
        //Change the reload time
        reloadTime -= Time.deltaTime;

        //Make sure the reload time is correct before firing
        if(reloadTime < 0)
        {
            //Load the arrow
            projectile.SetActive(true);
        }

        if ((Input.GetButtonDown("Fire1")) && (reloadTime < 0))
        {
            //Shoots the object and un reloads the arrow
            Shoot();
            projectile.SetActive(false);

            //Set the reload time
            reloadTime = countDown;
        }

    }

    private void Shoot()
    {
        RaycastHit _hit;

        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
                //We hit something
                Debug.Log("We hit " + _hit.collider.name);
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out  _hit, weapon.range, shootableMask))
            {
                EnemyHealth enemyhealth = _hit.collider.GetComponent<EnemyHealth>();
                if(enemyhealth != null)
                {
                    enemyhealth.TakeDamage(damage, _hit.point);
                }
            }
            //Instantiate(arrow, _hit.point, transform.rotation);
            //DrawALine(gun.transform.position, _hit.point, Color.yellow);
        }
      else
      {
           // DrawALine(gun.transform.position, rayOrigin + (cam.transform.forward * weapon.range), Color.yellow);
      }
        

    }

    void DrawALine(Vector3 start, Vector3 end, Color color)
    {
        //The code required to draw the line
        GameObject Line = new GameObject();
        Line.transform.position = start;
        Line.AddComponent<LineRenderer>();
        LineRenderer lr = Line.GetComponent<LineRenderer>();
        lr.material = null;
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(Line, duration);
    }

}
