using UnityEngine;

public interface ITakeDamage
{
    void TakeDamage(float amount);
}

public class FlashLight : MonoBehaviour
{
    public float damagePerSecond = 10f;

    void OnTriggerStay2D(Collider2D other)
    {
        ITakeDamage target = other.GetComponent<ITakeDamage>();
        if (target != null)
        {
            target.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
