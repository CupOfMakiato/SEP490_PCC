using AutoMapper;
using Server.Application.DTOs.Symptom;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.Symptom
{
    public class SymptomProfile : Profile
    {
        public SymptomProfile()
        {
            CreateMap<RecordedSymptom, ViewSymptomDTO>().ReverseMap();
        }
    }
}
