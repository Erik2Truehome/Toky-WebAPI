using TestTokyWebAPI.constant;

namespace TestTokyWebAPI.Model
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public BusinessTarget BusinessTarget { get; set; }


        public Assignment()
        {
            Status = AssignmentStatus.NOT_PROCESSED;
        }


        public Assignment(int id)
        {
            Id = id;
            Status = AssignmentStatus.NOT_PROCESSED;
        }

        public Assignment(int id, BusinessTarget businessTarget)
        {
            Id = id;
            BusinessTarget = businessTarget;
            Status = AssignmentStatus.NOT_PROCESSED;
        }
    }
}
