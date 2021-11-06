using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public List<Transform> possibleSpawnPoints;
    public float emergingSpeed = 10f;
    public GameObject projectile;
    
    private GameObject player;
    private Coroutine emergeCoroutine;
    private Coroutine throwCoroutine;
    private float projectileCooldown = 3f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Spawn();
    }

    void Spawn()
    {
        if (throwCoroutine != null)
        {
            StopCoroutine(throwCoroutine);
        }

        Vector3 spawnPoint = GetFurthestSpawnPointFromPlayer();
        spawnPoint.y -= 5f;
        transform.position = spawnPoint;
        emergeCoroutine = StartCoroutine(Emerge(spawnPoint.y + 5f));
    }

    Vector3 GetFurthestSpawnPointFromPlayer()
    {
        Vector3 furthestSpawnPoint = Vector3.zero;
        float furthestDistance = 0f;
        foreach (Transform possibleSpawnPoint in possibleSpawnPoints)
        {
            float currentSpawnPointDistance = Vector2.Distance(possibleSpawnPoint.position, player.transform.position);
            if (currentSpawnPointDistance > furthestDistance)
            {
                furthestDistance = currentSpawnPointDistance;
                furthestSpawnPoint = possibleSpawnPoint.position;
            }
        }

        return furthestSpawnPoint;
    }

    IEnumerator Emerge(float yTarget)
    {
        while (transform.position.y < yTarget)
        {
            transform.Translate(0, emergingSpeed * Time.fixedDeltaTime, 0);
            
            yield return new WaitForFixedUpdate();
        }

        throwCoroutine = StartCoroutine(ThrowProjectile());
    }

    IEnumerator ThrowProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(projectileCooldown);
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y + 3f);
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f, 5f), 15f);
        }
    }

    void OnHit(Hitbox hit)
    {
        hit.enabled = false;
        projectileCooldown -= 0.75f;
        Spawn();
        StartCoroutine(DestroyRock(hit.gameObject));
    }

    IEnumerator DestroyRock(GameObject rock)
    {
        yield return new WaitForSeconds(1f);
        Destroy(rock);
    }

    void OnDeath()
    {
        StopCoroutine(emergeCoroutine);
        StopCoroutine(throwCoroutine);
    }
}
