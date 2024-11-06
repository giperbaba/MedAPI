using Microsoft.AspNetCore.Mvc;

namespace medicalInformationSystem.Api.Controllers;

public class BaseController: ControllerBase
{
    protected Guid GetDoctorId()
    {
        var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

        if (doctorIdClaim == null) throw new UnauthorizedAccessException();

        if (!Guid.TryParse(doctorIdClaim.Value, out var doctorId)) throw new InvalidOperationException();

        return doctorId;
    }
}