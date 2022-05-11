using System;

namespace ApiQL.Models 
{    
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}