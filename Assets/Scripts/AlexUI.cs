using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Control the GUI elements.
/// </summary>
public class AlexUI : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider shieldSlider;
    [SerializeField] private TextMeshProUGUI currentAmmo;

    /// <summary>
    /// Set a new maximum value for the health bar and update the current
    /// health value to the new maximum
    /// </summary>
    /// <param name="health">New max health value</param>
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    /// <summary>
    /// Update health bar to new value. Set to maximum value if bigger than
    /// maximum is provided.
    /// </summary>
    /// <param name="health">New health value</param>
    public void SetHealth(int health)
    {
        if (health > healthSlider.maxValue) health = (int) healthSlider.maxValue;
        healthSlider.value = health;
    }

    /// <summary>
    /// Set a new maximum value for the shield bar and update the current
    /// shield value to the new maximum.
    /// </summary>
    /// <param name="shield">New max shield value</param>
    public void SetMaxShield(int shield)
    {
        shieldSlider.maxValue = shield;
        SetShield(shield);
    }

    /// <summary>
    /// Update shield bar to new value. Set to maximum value if bigger than
    /// maximum is provided.
    /// </summary>
    /// <param name="shield">New shield value</param>
    public void SetShield(int shield)
    {
        if (shield > shieldSlider.maxValue) shield = (int) shieldSlider.maxValue;
        shieldSlider.value = shield;
    }

    /// <summary>
    /// Toggle the visibility of the shield bar
    /// </summary>
    /// <param name="enable">true if shield bar should be visible
    /// otherwise false</param>
    public void EnableShield(bool enable)
    {
        shieldObject.SetActive(enable);
    }

    /// <summary>
    /// Update ammo value. Maximum 99, minimum 0.
    /// </summary>
    /// <param name="ammo"></param>
    public void SetAmmo(int ammo)
    {
        if (ammo > 99) ammo = 99;
        else if (ammo < 0) ammo = 0;

        currentAmmo.text = ammo.ToString();
    }
}
