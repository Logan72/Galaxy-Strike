using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"We hit {other.name}");
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
}
