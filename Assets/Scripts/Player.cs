using UnityEngine;
//using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    public float movementSpeed;
    public float rotationSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;

    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    //public NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        //agent = GetComponent<NavMeshAgent>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg - 90;
        //float currentRotZ = transform.eulerAngles.z;
        //float rotZ = Mathf.LerpAngle(currentRotZ, targetRotZ, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);

        if(currentHealth < 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
