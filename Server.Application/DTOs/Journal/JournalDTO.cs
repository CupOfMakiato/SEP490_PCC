﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Journal
{
    public class JournalDTO
    {
        public Guid Id { get; set; }
        public int CurrentWeek { get; set; }
        public int CurrentTrimester { get; set; }
        public string Note { get; set; }
        public float CurrentWeight { get; set; }
        public List<string> Symptoms { get; set; }
        public string Mood { get; set; }
    }
}
