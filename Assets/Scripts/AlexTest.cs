using UnityEngine;

/// <summary>
/// Test class and example for AlexUI script.
/// </summary>
public class AlexTest : MonoBehaviour
{
    public AlexUI ui;
    //public AlexEndSplash end;

    public int maxHealth = 100;
    public int currentHealth = 0;

    public int maxShield = 100;
    public int currentShield = 0;
    public bool shieldActivated = true;

    public int maxAmmo = 99;
    public int currentAmmo = 0;

    public int targetsLeft = 15;


    void Start()
    {
        currentHealth = maxHealth;
        ui.SetMaxHealth(maxHealth);

        currentShield = maxShield;
        ui.SetMaxShield(maxShield);
        ui.EnableShield(shieldActivated);

        currentAmmo = maxAmmo;
        ui.SetAmmo(maxAmmo);

        ui.SetDronesLeft(targetsLeft);

        ui.SetObjective("OBJECTIVE:\nKill all the drones!");

    }

    // Update is called once per frame
    void Update()
    {
        // More health
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentHealth = maxHealth;
            ui.SetHealth(currentHealth);
        }

        // Less health
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentHealth -= 20;
            ui.SetHealth(currentHealth);
        }

        // More shield
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentShield = maxShield;
            ui.SetShield(currentShield);
        }

        // Less shield
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentShield -= 20;
            ui.SetShield(currentShield);
        }

        // Toggle shield
        if (Input.GetKeyDown(KeyCode.S))
        {
            shieldActivated = !shieldActivated;
            ui.EnableShield(shieldActivated);
        }

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentAmmo -= 1;
            ui.SetAmmo(currentAmmo);
        }

        // Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
            ui.SetAmmo(currentAmmo);
        }

        // Win splash
        if (Input.GetKeyDown(KeyCode.W))
        {
            ui.SetEndMessage(AlexUI.WINNER);
            ui.DisplayEndMessage();
        }

        // Lose splash
        if (Input.GetKeyDown(KeyCode.L))
        {
            ui.SetEndMessage(AlexUI.LOSER);
            ui.DisplayEndMessage();
        }

        // Kill drone
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (targetsLeft > 0)
                targetsLeft--;
            ui.SetDronesLeft(targetsLeft);
        }

        // Kill player
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (targetsLeft > 0)
                targetsLeft--;
            ui.SetPlayersLeft(targetsLeft);
        }
    }
}
