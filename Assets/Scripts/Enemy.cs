using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Scoreboard scoreboard;
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] int health = 3;
    [SerializeField] int scoreValue = 25;

    //void Awake()
    //{
    //    scoreboard = FindFirstObjectByType<Scoreboard>();
    //}

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void MyDestroy()
    {        
        Scoreboard.ModifyScore(scoreValue);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        MyDestroy();
    }

    void ProcessHit()
    {
        if (--health == 0)
        {
            MyDestroy();
        }
    }
}
