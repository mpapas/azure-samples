using System;

namespace Model
{
    public class MyMessage
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
