using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public static Health Instance { get; private set; } //Singleton

    //Events
    public static event Action OnHealthChanged; //Event to update health ui

    [Header("Player Data/Stats")]
    [SerializeField] CharacterDataSO characterData;

    [SerializeField] GameObject player;

    //Health
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    public int CurrentHealth
    {
        get => currentHealth;

        private set
        {
            if (currentHealth != value)
            {
                currentHealth = Mathf.Clamp(value, 0, characterData.maxHealth);
                OnHealthChanged?.Invoke(); //Update health value
            }
        }
    }

    public int Damage
    {
        get => characterData.dmg;

        private set
        {
            if (characterData.dmg != value)
            {
                characterData.dmg = Mathf.Clamp(value, 0, characterData.dmg);
            }
        }
    }

    private void Awake()
    {
        if (Instance != null) //Singleton
        {
            Debug.LogWarning("More than one instance of PlayerData found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Start()
    {
        CurrentHealth = characterData.maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Test function
        {
            TakeDamage(1);
            Debug.Log("Player took damage");
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        //Update healt UI;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

            Die();
        }
    }

    private void Die()
    {
        player.SetActive(false); //Disable player gameobject
    }
}
