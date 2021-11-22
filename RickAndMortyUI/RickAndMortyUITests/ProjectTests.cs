using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using RickAndMortyUI.Controllers;
using RickAndMortyUI.Helper;
using RickAndMortyUI.Model;
using RickAndMortyUI.Service;
using Assert = NUnit.Framework.Assert;

namespace RickAndMortyUI.Tests
{
    [TestFixture]
    public class ProjectTests
    {
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddControllersWithViews();
            services.AddScoped<IRequestHelper, RequestHelper>();
            services.AddScoped<IApiService, ApiService>();

            return services.BuildServiceProvider();
        }

        [Test]
        public void GetCharsWithEpisodeInfo_WhenIllegalPageGiven_ShouldFail()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            Assert.Throws<ArgumentNullException>(() => apiService.GetCharsWithEpisodeInfo(566));
        }

        [Test]
        public void GetCharsWithEpisodeInfo_WhenLegalPageGiven_ShouldPass()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            Assert.IsInstanceOf(typeof(MainList), apiService.GetCharsWithEpisodeInfo());
        }

        [Test]
        public void GetChars_WhenLegalPageGiven_ShouldPass()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            Assert.IsInstanceOf(typeof(MainList), apiService.GetChars());
        }

        [Test]
        public void Index_WhenLegalPageGiven_ShouldPass()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            var controller = new HomeController(apiService);

            Assert.IsInstanceOf(typeof(IActionResult), controller.Index());
        }

        [Test]
        public void Error_WhenRouted_ShouldPass()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            var controller = new HomeController(apiService);

            Assert.IsInstanceOf(typeof(IActionResult), controller.Error());
        }

        
        [Test]
        public void Error_WhenErrorHappened_ShouldFail()
        {
            var services = GetServiceProvider();

            var apiService = services.GetService<IApiService>();

            var controller = new HomeController(apiService);

            Assert.Throws<ArgumentNullException>(() => controller.Index(966));
        }

        [Test]
        public void ConfigureServices_RegistersDependenciesCorrectly()
        {
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
            Mock<IConfiguration> configurationStub = new Mock<IConfiguration>();
            IServiceCollection services = new ServiceCollection();
            var target = new Startup(configurationStub.Object);

            //  Act
            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<HomeController>();

            //  Assert
            var serviceProvider = services.BuildServiceProvider();

            var controller = serviceProvider.GetService<HomeController>();
            Assert.IsNotNull(controller);
        }

    }
}