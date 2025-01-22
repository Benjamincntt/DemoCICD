using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Domain;
using FluentAssertions;
using NetArchTest.Rules;

namespace DemoCICD.Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "DemoCICD.Domain";
    private const string ApplicationNamespace = "DemoCICD.Application";
    private const string InfrastructureNamespace = "DemoCICD.Infrastructure";
    private const string PersistenceNamespace = "DemoCICD.Persistence";
    private const string PresentationNamespace = "DemoCICD.Presentation";
    private const string ApiNamespace = "DemoCICD.API";

    // không cho reference lung tung các project => khi rreference vãn chưa bắt lỗi mà khi add thật sự thì mới báo lỗi
    [Fact]
    public void Domain_Should_Not_HaveDependenceOnOtherProject()
    {
        // Arrange
        var assembly = AssemblyReference.Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependenceOnOtherProject()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProject()
    {
        // Arrange
        var assembly = Infrastructure.AssemblyReference.Assembly;
        var otherProjects = new[]
        {
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnOtherProject()
    {
        // Arrange
        var assembly = Persistence.AssemblyReference.Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProject()
    {
        // Arrange
        var assembly = Presentation.AssemblyReference.Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            ApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    #region =========== Commmand ===========

    [Fact]
    public void Command_Should_Have_NamingConventionEndingCommand()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should().HaveNameEndingWith("Command")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandT_Should_Have_NamingConventionEndingCommand()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should().HaveNameEndingWith("Command")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Command_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandT_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandHandlers_Should_Have_NamingConventionEndingCommandHandler()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Should().HaveNameEndingWith("CommandHandler")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandHandlers_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void HandlerT_Should_Have_NamingConventionEndingCommandHandler()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should().HaveNameEndingWith("CommandHandler")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void HandlersT_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    #endregion End Command

    #region =========== Query ===========

    [Fact]
    public void Query_Should_Have_NamingConventionEndingQuery()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should().HaveNameEndingWith("Query")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Query_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandlers_Should_Have_NamingConventionEndingQueryHandler()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should().HaveNameEndingWith("QueryHandler")
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandlers_Should_Have_BeSealed()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should().BeSealed()
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    #endregion
}