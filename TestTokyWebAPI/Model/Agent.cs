namespace TestTokyWebAPI.Model
{
    public class Agent
    {
        public int IdIntern { get; set; }
        public string IdAssignator { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public string Lastname { get; set; }

        //estos ulitmos 3 son opcionales
        public string IvrPhone { get; set; }
        public string ImageUrl { get; set; }
        public Telephone TelephoneForwarding { get; set; }
    }
}
