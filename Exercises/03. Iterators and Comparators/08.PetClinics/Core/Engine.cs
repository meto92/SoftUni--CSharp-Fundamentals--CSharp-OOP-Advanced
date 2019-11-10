using System;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private PetClinicController petClinicController;

    public Engine(IInputReader reader, IOutputWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.petClinicController = new PetClinicController();
    }

    public void Run()
    {
        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string input = reader.ReadLine();

            string[] commandParams = input.Split();

            Command command = Enum.Parse<Command>(commandParams[0]);

            string petName = string.Empty;
            string clinicName = string.Empty;
            object result = null;

            switch (command)
            {
                case Command.Create:
                    switch (commandParams[1])
                    {
                        case "Pet":
                            petName = commandParams[2];
                            int petAge = int.Parse(commandParams[3]);
                            string petKind = commandParams[4];

                            this.petClinicController.CreatePet(petName, petAge, petKind);
                            break;
                        case "Clinic":
                            clinicName = commandParams[2];
                            int rooms = int.Parse(commandParams[3]);

                            try
                            {
                                this.petClinicController.CreateClinic(clinicName, rooms);
                            }
                            catch (ArgumentException aex)
                            {
                                this.writer.WriteLine(aex.Message);
                            }

                            break;
                    }

                    break;
                case Command.Add:
                    petName = commandParams[1];
                    clinicName = commandParams[2];

                    result = this.petClinicController.AddPet(petName, clinicName);
                    break;
                case Command.Release:
                    clinicName = commandParams[1];

                    result = this.petClinicController.Release(clinicName);
                    break;
                case Command.HasEmptyRooms:
                    clinicName = commandParams[1];

                    result = this.petClinicController.HasEmptyRoom(clinicName);
                    break;
                case Command.Print:
                    clinicName = commandParams[1];

                    if (commandParams.Length == 2)
                    {
                        result = this.petClinicController.Print(clinicName);
                    }
                    else if (commandParams.Length > 2)
                    {
                        int room = int.Parse(commandParams[2]);

                        result = this.petClinicController.Print(clinicName, room);
                    }

                    break;
            }

            if (result != null)
            {
                this.writer.WriteLine(result.ToString());
            }
        }        
    }
}