using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly PrescriptionService _prescriptionService;

    public PrescriptionController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public IActionResult CreatePrescription([FromBody] PrescriptionDto prescriptionDto)
    {
        try
        {
            _prescriptionService.AddPrescription(prescriptionDto);
            return Ok("Prescription created successfully.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}