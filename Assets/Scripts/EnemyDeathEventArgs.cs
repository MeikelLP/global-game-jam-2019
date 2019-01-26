using System;

public class EnemyDeathEventArgs : EventArgs 
{
    public PlayerShooting Killer { get; set; }
    public EnemyHealth Enemy { get; set; }
}