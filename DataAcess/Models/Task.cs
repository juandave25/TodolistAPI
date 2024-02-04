using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Priority { get; set; }   
    }
}
