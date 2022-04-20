using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armour;

    [Header("Health")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float timeBeforeRegenStarts = 3;
    [SerializeField] private float healthValueIncrement = 1;
    [SerializeField] private float healthTimeIncrement = 1;
    public float currentHealth { get; private set; }
    private Coroutine regeneratingHealth;
    public static Action<float> OnTakeDamage;
    public static Action<float> OnDamage;
    public static Action<float> OnHeal;

    private void OnEnable()
    {
        OnTakeDamage += ApplyDamage;
    }
    private void OnDisable()
    {
        OnTakeDamage -= ApplyDamage;
    }
    void Awake()
    {
        currentHealth = maxHealth;
    }
    //private void HandleStamina()
    //{
    //    if (isSprinting && currentInput != Vector2.zero)
    //    {
    //        if (regeneratingStamina != null)
    //        {
    //            StopCoroutine(regeneratingStamina);
    //            regeneratingStamina = null;
    //        }

    //        currentStamina -= staminaUseMultiplier * Time.deltaTime;

    //        if (currentStamina < 0)
    //            currentStamina = 0;

    //        OnStaminaChange?.Invoke(currentStamina);

    //        if (currentStamina <= 0)
    //            canSprint = false;
    //    }
    //    if (!isSprinting && currentStamina < maxStamina && regeneratingStamina == null)
    //    {
    //        regeneratingStamina = StartCoroutine(RegerateStamina());
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ApplyDamage(10);
        }
    }
    private void ApplyDamage(float dmg)
    {
        dmg -= armour.GetValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);

        currentHealth -= dmg;
        OnDamage?.Invoke(currentHealth);

        if (currentHealth <= 0)
            Die();
        else if (regeneratingHealth != null)
            StopCoroutine(regeneratingHealth);

        regeneratingHealth = StartCoroutine(RegenerateHealth());
    }
    public virtual void Die()
    {
        currentHealth = 0;

        if (regeneratingHealth != null)
            StopCoroutine(regeneratingHealth);

        print(transform.name + "Died");
    }
    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(healthTimeIncrement);

        while (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Lerp(currentHealth, (currentHealth + healthValueIncrement), healthTimeIncrement * Time.deltaTime);

            if (currentHealth > maxHealth)
                currentHealth = maxHealth;

            OnHeal?.Invoke(currentHealth);
            yield return null;
        }

        regeneratingHealth = null;
    }
    //private IEnumerator RegerateStamina()
    //{
    //    yield return new WaitForSeconds(timeBeforeStaminaRegenStarts);
    //    WaitForSeconds timeToWait = new WaitForSeconds(staminaTimeIncrement);

    //    while (currentStamina < maxStamina)
    //    {
    //        if (currentStamina > 0)
    //            canSprint = true;

    //        currentStamina = Mathf.Lerp(currentStamina, (currentStamina + staminaValueIncrement), staminaTimeIncrement * Time.deltaTime);

    //        if (currentStamina > maxStamina)
    //            currentStamina = maxStamina;

    //        OnStaminaChange?.Invoke(currentStamina);
    //        yield return null;
    //    }

    //    regeneratingStamina = null;
    //}
}
