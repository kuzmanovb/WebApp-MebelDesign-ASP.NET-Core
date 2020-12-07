namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class TemplateTest : IDisposable
    {
        private readonly ISettingsService settingsService;
        private EfDeletableEntityRepository<Setting> settingRepository;
        private ApplicationDbContext connection;

        private Setting firstSetting;

        public TemplateTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.settingRepository = new EfDeletableEntityRepository<Setting>(this.connection);
            this.InitializeFields();

            this.settingsService = new SettingsService(this.settingRepository);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        // Start Testing -------------------------------------------------------------------------------------------------------

        [Fact]
        public async Task TestAddingSetting()
        {
            var model = new Setting
            {
                Name = "Mol Sofia",
                Value = "Bulgaria, Sofia",
            };

            await this.settingsService.AddSettingAsync(model);
            var count = await this.settingRepository.All().CountAsync();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task TestGetCount()
        {
            var model = new Setting
            {
                Name = "Mol Sofia",
                Value = "Bulgaria, Sofia",
            };

            await this.settingsService.AddSettingAsync(firstSetting);
            await this.settingsService.AddSettingAsync(model);
            var count = this.settingsService.GetCount();

            Assert.Equal(2, count);
        }

        // End Testing ---------------------------------------------------------------------------------------------------------------
        private void InitializeFields()
        {
            this.firstSetting = new Setting
            {
                Name = "Test Name",
                Value = "Test Value",
            };
        }
    }
}
