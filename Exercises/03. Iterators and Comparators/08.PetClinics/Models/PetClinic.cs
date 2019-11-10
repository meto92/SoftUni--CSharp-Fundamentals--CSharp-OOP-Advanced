using System;
using System.Text;

public class PetClinic
{
    private const string InvalidRoomsCount = "Invalid Operation!";
    private const string RoomEmptyMessage = "Room empty";

    private string name;
    private int roomsCount;
    private Pet[] rooms;
    private int freeRoomsCount;

    public PetClinic(string name, int rooms)
    {
        this.Name = name;
        this.RoomsCount = rooms;
        this.freeRoomsCount = this.RoomsCount;
        this.rooms = new Pet[roomsCount];
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int RoomsCount
    {
        get => this.roomsCount;

        private set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException(InvalidRoomsCount);
            }

            this.roomsCount = value;
        }
    }

    public bool AddPet(Pet pet)
    {
        int index = this.RoomsCount / 2,
            lastLeftIndex = index,
            lastRightIndex = index;

        bool isNextIndexLeft = true;

        while (index != -1)
        {
            if (this.rooms[index] == null)
            {
                this.freeRoomsCount--;
                this.rooms[index] = pet;

                return true;
            }

            if (isNextIndexLeft)
            {
                index = lastLeftIndex - 1;
                lastLeftIndex = index;
                isNextIndexLeft = false;
            }
            else
            {
                index = lastRightIndex + 1;
                lastRightIndex = index;
                isNextIndexLeft = true;
            }
        }

        return false;
    }

    public string Print()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 1; i <= this.RoomsCount; i++)
        {
            result.AppendLine(this.Print(i));
        }

        return result.ToString().TrimEnd();
    }

    public string Print(int room)
    {
        string result = RoomEmptyMessage;

        if (this.rooms[room - 1] != null)
        {
            result = this.rooms[room - 1].ToString();
        }

        return result;
    }

    public bool ReleasePet()
    {
        for (int i = this.RoomsCount / 2; i < this.RoomsCount + this.RoomsCount / 2; i++)
        {
            if (this.rooms[i % this.RoomsCount] != null)
            {
                this.rooms[i] = null;
                this.freeRoomsCount++;

                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms => this.freeRoomsCount > 0;
}