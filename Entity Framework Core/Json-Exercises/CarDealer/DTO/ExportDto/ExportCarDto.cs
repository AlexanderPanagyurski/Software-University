﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.ExportDto
{
    public class ExportCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<ExportPartDto> parts { get; set; }
    }
}