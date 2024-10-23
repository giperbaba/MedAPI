namespace medicalInformationSystem.Model.Request;

public class ConsultationCreateModel
{
    public ConsultationCreateModel(InspectionCommentCreateModel comment)
    {
        Comment = comment;
    }

    public Guid SpecialityId { get; set; }
    public InspectionCommentCreateModel Comment { get; set; }
}