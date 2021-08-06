using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolvexWorkshop.Model.Contexts;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Mapper;
using SolvexWorkShop.Core.Settings;
using System;

namespace SolvexWorkShop.Services.Tests
{
    public class ServicesTestsFixture : ServicesTestsData, IDisposable
    {
        public DbContextOptionsBuilder<WorkShopContext> OptionsBuilder { get; private set; }

        public WorkShopContext Context { get; private set; }
        public IOptions<JwtSettings> Settings;
        public IMapper Mapper;

        public ServicesTestsFixture()
        {
            #region Automapper

            Mapper = new MapperConfiguration(x => x.AddProfile<MappingProfile>()).CreateMapper();

            #endregion

            #region Repository

            OptionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            OptionsBuilder.UseInMemoryDatabase("WorkShop2");

            Context = new WorkShopContext(OptionsBuilder.Options);

            Context.Users.AddRange(_emmanuel, _maryelin);
            Context.WorkShops.AddRange(_workShop1);
            Context.WorkShopDays.AddRange(_monday);
            Context.WorkShopMembers.AddRange(_memberMaryelin);
            Context.Documents.AddRange(_document1);

            Context.SaveChanges();

            #endregion

            #region Option Settings

            Settings = Options.Create(new JwtSettings
            {
                ExpiresInMinutes = 10,
                Secret = "0263875b-b775-4426-938c-ab7c04c74b22"
            });

            #endregion

        }

        public void Dispose()
        {
        }
    }
}
