using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public abstract class AbstractEntityBuilder<Type>
        where Type : new()
    {
        protected Type instance = new ();
        public virtual AbstractEntityBuilder<Type> Begin()
        {
            instance = new Type();
            return this;
        }
        public Type End()
        {
            Type returnedObject = instance;
            instance = new Type();
            return returnedObject;
        }
    }
}
