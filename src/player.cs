using System;

class Player
{
    // Auto property for current room
    public Room CurrentRoom { get; set; }

    // Health property
    public int Health { get; private set; }

    // Timer for damage over time (fully qualified to avoid CS0104)
    private System.Timers.Timer damageTimer;

    // Constructor
    public Player()
    {
        CurrentRoom = null;
        Health = 100;

        // Set up the damage timer: triggers every 20 seconds
        damageTimer = new System.Timers.Timer(20000); // 20,000 ms = 20 sec
        damageTimer.Elapsed += OnDamageEvent;
        damageTimer.AutoReset = true; // repeat automatically
        damageTimer.Enabled = true;   // start the timer
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"Player took {damage} damage! Health is now {Health}.");
    }

    // Timer event: called every 20 seconds
    private void OnDamageEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        TakeDamage(5);
    }

    // Optional: stop the timer if the player dies or game ends
    public void StopDamageTimer()
    {
        damageTimer.Stop();
        damageTimer.Dispose();
    }
}
