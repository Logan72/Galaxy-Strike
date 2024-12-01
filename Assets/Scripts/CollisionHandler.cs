using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] GameSceneManagement gameSceneManagement;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameSceneManagement.ReloadScene();
    }    
}
