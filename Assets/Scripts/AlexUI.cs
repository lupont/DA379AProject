using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Control the GUI elements.
/// </summary>
public class AlexUI : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject = null;
    [SerializeField] private Slider healthSlider = null;
    [SerializeField] private Slider shieldSlider = null;
    [SerializeField] private TextMeshProUGUI currentAmmo = null;
    [SerializeField] private Gradient healthGradient = null;
    [SerializeField] private Gradient shieldGradient = null;
    [SerializeField] private Image healthFill = null;
    [SerializeField] private Image shieldFill = null;
    [SerializeField] private TextMeshProUGUI targetsLeft = null;
    [SerializeField] private TextMeshProUGUI objective = null;
    [SerializeField] private TextMeshProUGUI endMessage = null;
    [SerializeField] private GameObject endSplash = null;
    [SerializeField] private GameObject hud = null;

    // End splash
    public const int WINNER = 0;
    public const int LOSER = 1;
    private string[] messages = { "You are victorious", "You are a loser" };

    public void Start()
    {
        Time.timeScale = 1f;
        AlexPauseMenu.GameIsPaused = false;
    }

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
        if (health > healthSlider.maxValue) health = (int)healthSlider.maxValue;
        healthSlider.value = health;
        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
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
        if (shield > shieldSlider.maxValue) shield = (int)shieldSlider.maxValue;
        shieldSlider.value = shield;
        shieldFill.color = shieldGradient.Evaluate(shieldSlider.normalizedValue);
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

    /// <summary>
    /// Set game objective text
    /// </summary>
    /// <param name="newObjective"></param>
    public void SetObjective(string newObjective)
    {
        objective.text = newObjective;
    }

    /// <summary>
    /// Update number of drones left
    /// </summary>
    /// <param name="drones"></param>
    public void SetDronesLeft(int drones)
    {
        targetsLeft.text = "Drones left: " + drones;
    }

    /// <summary>
    /// Update number of players left
    /// </summary>
    /// <param name="players"></param>
    public void SetPlayersLeft(int players)
    {
        targetsLeft.text = "Players left: " + players;
    }

    /// <summary>
    /// Set end message
    /// </summary>
    /// <param name="index"></param>
    public void SetEndMessage(int index)
    {
        if (index < 0 || index > 1)
            index = 1;

        endMessage.text = messages[index];
    }

    public void DisplayEndMessage()
    {
        hud.SetActive(false);
        endSplash.SetActive(true);
        Time.timeScale = 0f;
        AlexPauseMenu.GameIsPaused = true;
    }

}
