using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maximumHealth;

    private int currentHealth;
    private bool isInvincible = false;
    public UnityEvent<int> onHealthChange { get; } = new UnityEvent<int>();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    public void ApplyInvincibility()
    {
        isInvincible = true;
    }

    public void RemoveInvincibility()
    {
        isInvincible = false;
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            SetCurrentHealth(currentHealth - damage);
        }
    }

    public void Heal(int heal)
    {
        SetCurrentHealth(currentHealth + heal);
    }

    public void FullHeal()
    {
        SetCurrentHealth(maximumHealth);
    }

    private void SetCurrentHealth(int value)
    {
        currentHealth = Mathf.Clamp(value, 0, maximumHealth);
        onHealthChange.Invoke(value);
        if (currentHealth == 0)
        {
            SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnHit(Hitbox hitbox)
    {
        TakeDamage(hitbox.damage); 

        if (currentHealth == 0)
        {
            hitbox.gameObject.transform.root.gameObject.BroadcastMessage("OnKill", gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }
}