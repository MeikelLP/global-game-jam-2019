using System;

public class ComboEventArgs : EventArgs
{
    public int Combo { get; set; }
    public PlayerShooting Player { get; set; }
}