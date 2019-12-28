using System;


namespace Domain.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

        public PrimaryKey()
        {
        }
        
    }
}
