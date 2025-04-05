using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; } 
        public int ObjectiveId {  get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Created_At {  get; set; }
        public DateTime Updated_At { get;set; }
     
    }
}
