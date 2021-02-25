using System;
using Xunit;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Profiles;


namespace CommandAPI.Tests
{
    public class CommandsControllerTests
    {
        [Fact]
        public void  GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            //Arrange
            var mockRepo=new Mock<ICommandAPIRepo>();
            mockRepo.Setup(repo=>repo.GetAllCommands()).Returns(GetCommands(0));
            var realProfile=new CommandsProfile();
            var configuration=new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            IMapper mapper=new Mapper(configuration);
            //We need to create an instance of our CommandsController class
            var controller=new CommandsController(mockRepo.Object,mapper);
        }

        private IEnumerable<Command> GetCommands(int num)
        {
            var commands=new List<Command>();
            if(num>0){
                commands.Add(new Command{
                    Id=0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                     Platform = ".Net Core EF"

                });
            }
            return commands;
        }
    }
}