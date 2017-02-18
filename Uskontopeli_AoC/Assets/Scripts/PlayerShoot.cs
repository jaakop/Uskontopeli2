using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private float duration = 1f;


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
        
            if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
            DrawALine(gun.transform.position, _hit.point, Color.yellow);
        }
      else
      {
            DrawALine(gun.transform.position, rayOrigin + (cam.transform.forward * weapon.range), Color.yellow);
      }
        

    }

    void DrawALine(Vector3 start, Vector3 end, Color color)
    {
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
