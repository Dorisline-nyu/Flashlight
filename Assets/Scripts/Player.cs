using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    public float movementSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed);
    }
}
