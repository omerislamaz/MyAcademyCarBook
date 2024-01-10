﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class CarStatus
    {
        public int CarStatusID { get; set; }
        public int CarStatusName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
