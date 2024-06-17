using Cwiczenia10.Models;

public class PrescriptionService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPatientRepository patientRepository, IMedicamentRepository medicamentRepository, IPrescriptionRepository prescriptionRepository)
    {
        _patientRepository = patientRepository;
        _medicamentRepository = medicamentRepository;
        _prescriptionRepository = prescriptionRepository;
    }

    public void AddPrescription(PrescriptionDto prescriptionDto)
    {
        if (prescriptionDto == null)
        {
            throw new ArgumentNullException(nameof(prescriptionDto));
        }

        if (prescriptionDto.Patient == null)
        {
            throw new ArgumentNullException(nameof(prescriptionDto.Patient));
        }

        if (prescriptionDto.Medicaments == null)
        {
            throw new ArgumentNullException(nameof(prescriptionDto.Medicaments));
        }

        if (prescriptionDto.Medicaments.Count > 10)
        {
            throw new ArgumentException("Prescription can include a maximum of 10 medicaments.");
        }

        if (prescriptionDto.DueDate < prescriptionDto.Date)
        {
            throw new ArgumentException("DueDate cannot be earlier than Date.");
        }

        var patient = _patientRepository.GetPatientByName(prescriptionDto.Patient.FirstName, prescriptionDto.Patient.LastName);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = prescriptionDto.Patient.FirstName,
                LastName = prescriptionDto.Patient.LastName,
                Birthdate = prescriptionDto.Patient.Birthdate
            };
            _patientRepository.AddPatient(patient);
            _patientRepository.Save();
        }

        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = prescriptionDto.IdDoctor,
            PrescriptionMedicaments = new List<Prescription_Medicament>()
        };

        foreach (var medicamentDto in prescriptionDto.Medicaments)
        {
            var medicament = _medicamentRepository.GetMedicamentById(medicamentDto.IdMedicament);
            if (medicament == null)
            {
                throw new ArgumentException($"Medicament with ID {medicamentDto.IdMedicament} does not exist.");
            }

            var prescriptionMedicament = new Prescription_Medicament
            {
                IdMedicament = medicamentDto.IdMedicament,
                IdPrescription = prescription.IdPrescription,  
                Dose = medicamentDto.Dose,
                Details = medicamentDto.Details
            };

            prescription.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        _prescriptionRepository.AddPrescription(prescription);
        _prescriptionRepository.Save();
    }
}
