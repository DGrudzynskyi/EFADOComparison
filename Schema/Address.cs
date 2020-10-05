using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFExampleBasic.Schema
{
    [ComplexType]
    public class Address
    {
        public string City { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
    }
}
