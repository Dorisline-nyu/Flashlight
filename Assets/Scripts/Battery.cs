using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private int batLife = 25;
    [SerializeField] private ResourceBar resourceBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeBatLife();
        }
    }
    public void ChangeBatLife()
    {
        bool batPickUp = resourceBar.ChangeResourceByAmount(batLife);

        if (batPickUp)
            Debug.Log("Pick up bat");
        else
            Debug.Log("No");
    }
}
