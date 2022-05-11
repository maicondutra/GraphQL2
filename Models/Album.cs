namespace ApiQL.Models {
    public class Album {
        public System.Guid Id { get; set; }
        public string Name { get; set; }                
        public Artist Artist { get; set; }
    }
}