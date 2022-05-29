using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IEntity
    {

    }
    public abstract class BaseEntity<Tkey>:IEntity
    {
        public Tkey ID { get; set; }
        
    }
    public class BaseEntity : BaseEntity<int>
    {

    }
}
