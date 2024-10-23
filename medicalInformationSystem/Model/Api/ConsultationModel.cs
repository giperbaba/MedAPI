namespace medicalInformationSystem.Model.Api;

public class ConsultationModel
{
    public Guid Id { get; set; }

    private DateTime CreateTime { get; set; }

    public Guid InspectionId { get; set; }

    public SpecialityModel Speciality { get; set; }

    public List<CommentModel> Comments { get; set; }
}