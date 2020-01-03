
using System;

namespace Domain.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
              

        public PrimaryKey()
        {
            //type checking commented out (too expensive)
            //StackFrame frame = new StackFrame(1);
            //var tableType = frame.GetMethod().DeclaringType;
            
            //if (!tableType.GetInterfaces().Contains(typeof(IDataTable)))
            //    throw new Exception("Can not use this attribute. Class does not implement IDataTable");
        }


    }

    
}
