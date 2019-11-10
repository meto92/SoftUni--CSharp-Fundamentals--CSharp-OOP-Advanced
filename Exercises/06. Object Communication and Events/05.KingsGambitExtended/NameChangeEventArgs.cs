using System;

public class KingBeingAttackedEventArgs : EventArgs
{
    private string message;

    public KingBeingAttackedEventArgs(string message)
    {
        this.Message = message;
    }

    public string Message
    {
        get => this.message;
        private set => this.message = value;
    }
}