using System;

public class KingAttackedEventArgs : EventArgs
{
    private string message;

    public KingAttackedEventArgs(string message)
    {
        this.Message = message;
    }

    public string Message
    {
        get => this.message;
        private set => this.message = value;
    }
}