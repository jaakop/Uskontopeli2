using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject gun;

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
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
                //We hit something
                Debug.Log("We hit " + _hit.collider.name);
            DrawALine(gun.transform.position, _hit.point, Color.yellow);
        }
     // else
     // {
     //     DrawALine(gun.transform.position, _hit.point, Color.yellow);
     // }
        

    }

    void DrawALine(Vector3 start, Vector3 end, Color color,float duration = 0.1f)
    {
        GameObject Line = new GameObject();
        Line.transform.position = start;
        Line.AddComponent<LineRenderer>();
        LineRenderer lr = Line.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(Line, duration);
    }

}
