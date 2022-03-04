namespace TestTokyWebAPI.Model
{
    public class Lead
    {
        public int IdIntern { get; set; }
        public string IdAssignator { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public string UrlProperty { get; set; }
        public Telephone Telephone { get; set; }
    }
}
