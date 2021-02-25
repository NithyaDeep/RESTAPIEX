using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests{
    public class CommandTests:IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
             testCommand=new Command{
                HowTo="Do Something Awesome",
                Platform="xUnit",
                CommandLine="dotnet test"
            };
        }

        public void Dispose(){testCommand = null;}

        [Fact]
        public void CanChangeHowTo()
        {

            //Arrange
            //Act
            testCommand.HowTo="Execute Unit Tests";
            
            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
            
           

        }

        [Fact]
        public void CanChangePlatform(){
            //Arrange
            //Act
            testCommand.Platform="pl";
            //Assert
             Assert.Equal("pl", testCommand.Platform);
        }


        [Fact]
        public void CanChangeCommandLine(){
            //Arrange
            
            //Act
            testCommand.CommandLine="cli";
            //Assert
            Assert.Equal("cli", testCommand.CommandLine);
        }
    }
}