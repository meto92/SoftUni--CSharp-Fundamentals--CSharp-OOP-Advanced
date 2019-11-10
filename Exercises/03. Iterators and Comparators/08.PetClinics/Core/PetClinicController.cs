using System.Collections.Generic;

public class PetClinicController
{
    private IDictionary<string, PetClinic> petClinicByName;
    private IDictionary<string, Pet> petByName;

    public PetClinicController()
    {
        this.petByName = new Dictionary<string, Pet>();
        this.petClinicByName = new Dictionary<string, PetClinic>();
    }

    private PetClinic GetClinicByName(string clinicName)
    {
        PetClinic petClinic = this.petClinicByName[clinicName];

        return petClinic;
    }

    public void CreatePet(string name, int age, string kind)
    {
        Pet pet = new Pet(name, age, kind);

        this.petByName[name] = pet;
    }

    public void CreateClinic(string name, int rooms)
    {
        PetClinic petClinic = new PetClinic(name, rooms);

        this.petClinicByName[name] = petClinic;
    }

    public bool AddPet(string petName, string clinicName)
    {
        Pet pet = this.petByName[petName];
        PetClinic petClinic = this.GetClinicByName(clinicName);

        return petClinic.AddPet(pet);
    }

    public bool Release(string clinicName)
    {
        PetClinic petClinic = this.GetClinicByName(clinicName);

        return petClinic.ReleasePet();
    }

    public bool HasEmptyRoom(string clinicName)
    {
        PetClinic petClinic = this.GetClinicByName(clinicName);

        return petClinic.HasEmptyRooms;
    }

    public string Print(string clinicName)
    {
        PetClinic petClinic = this.GetClinicByName(clinicName);

        return petClinic.Print();
    }

    public string Print(string clinicName, int room)
    {
        PetClinic petClinic = this.GetClinicByName(clinicName);

        return petClinic.Print(room);
    }
}