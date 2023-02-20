using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    Rigidbody2D rb;
    float horizontalInput, verticalInput;
    Vector2 dir;
    float angle;
    [SerializeField] private MovementControlType controlType;
    [SerializeField] private KeyCode shootBtn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private TMP_Text scoretxt;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();

        if(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput) != 0)
        {
            LookTowardsVel();
        }
        
    }

    private void FixedUpdate()
    {
        dir = Vector2.up * verticalInput;
        dir += Vector2.right * horizontalInput;
        rb.velocity = dir.normalized * speed * Time.deltaTime;
    }

    private void UserInput()
    {
        if(controlType == MovementControlType.Arrows)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal1");
            verticalInput = Input.GetAxisRaw("Vertical1");

        } else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal2");
            verticalInput = Input.GetAxisRaw("Vertical2");
        }

        if (Input.GetKeyDown(shootBtn))
        {
            Instantiate(projectile, spawnPos.position, spawnPos.rotation);
            CameraShake.instance.StartShake(0.5f, 0.15f);
            
        }
    }

    private void LookTowardsVel()
    {
        var dir = rb.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 700 * Time.deltaTime);
    }

    public enum MovementControlType
    {
        WASD,
        Arrows
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            if (scoretxt is null) return;

            scoretxt.SetText((++score).ToString());
            Destroy(collision.gameObject);
        }
    }
}
