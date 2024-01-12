﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCErrorDemoEFCoreExtensions
{
    public class ParentClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<ChildClass> Children { get; set; } = new ObservableCollection<ChildClass>();
    }
}
