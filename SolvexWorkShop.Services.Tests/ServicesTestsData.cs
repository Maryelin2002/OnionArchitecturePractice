using SolvexWorkshop.Model.Entities;
using System;

namespace SolvexWorkShop.Services.Tests
{
    public class ServicesTestsData
    {
        public readonly User _emmanuel = new User
        {
            Name = "Emmanuel",
            MiddleName = "Enrique",
            LastName = "Jimenez",
            SecondLastName = "Pimentel",
            Dob = new System.DateTime(1996, 06, 16),
            DocumentType = Core.Enums.DocumentType.ID,
            DocumentTypeValue = "22500851658",
            Gender = Core.Enums.Gender.MALE,
            UserName = "emmanuel",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234")
        };
        public readonly User _maryelin = new User
        {
            Name = "Maryelin",
            MiddleName = "V",
            LastName = "Ramirez",
            SecondLastName = "Alvarez",
            Dob = new System.DateTime(2002, 11, 29),
            DocumentType = Core.Enums.DocumentType.ID,
            DocumentTypeValue = "40232338166",
            Gender = Core.Enums.Gender.FEMALE,
            UserName = "maryelinram",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234")
        };
        public readonly WorkShop _workShop1 = new WorkShop
        {
            Name = "Solvex WorkShop 2",
            Description = "We are here to practice a lot!",
            StartDate = new System.DateTime(2021, 06, 18),
            EndDate = null,
            ContentSupport = "https://github.com/EmmanuelJP/SolvexWorkShops",

        };
        public readonly WorkShopDay _monday = new WorkShopDay
        {
            Day = 0,
            Mode = 0,
            ModeLocation = "(Salón Coliseo de Solvex - https://g.page/solvexdo?share - Calle Eugenio Deschamps 6, Santo Domingo 10133)",
            StartHour = new TimeSpan(3, 0, 0),
            EndHour = null,
            WorkShopId = 1
        };
        public readonly WorkShopMember _memberMaryelin = new WorkShopMember
        {
            Role = 0,
            WorkShopId = 1,
            UserId = 2,
        };
        public readonly Document _document1 = new Document
        {
            FileName = "Documento 1",
            OriginalName = "Documento 1",
            ContentType = "Adobe Acrobat Document (.pdf)"
        };
    }
}