using System;

namespace ApiQL.Models 
{
    public class Album 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }                
        public Artist Artist { get; set; }
    }
}