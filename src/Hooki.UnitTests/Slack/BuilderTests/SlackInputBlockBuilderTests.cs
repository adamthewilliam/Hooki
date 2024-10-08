using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackInputBlockBuilderTests
{
    private readonly SlackTextObject _validLabel = new SlackTextObject { Text = "Input Label", Type = SlackTextObjectType.PlainText };
    private readonly Func<IInputBlockElement> _validElement = () => new SlackPlainTextInputElement { ActionId = "input1" };

    [Fact]
    public void Build_With_Required_Properties_Returns_Valid_InputBlock()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder()
            .WithLabel(_validLabel)
            .WithElement(_validElement);

        // Act
        var result = builder.Build() as SlackInputBlock;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SlackInputBlock>();
        result?.Label.Should().Be(_validLabel);
        result?.Element.Should().BeOfType<SlackPlainTextInputElement>();
        result?.DispatchAction.Should().BeNull();
        result?.Hint.Should().BeNull();
        result?.Optional.Should().BeNull();
        result?.BlockId.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_Returns_Valid_InputBlock()
    {
        // Arrange
        var hint = new SlackTextObject { Text = "Input Hint", Type = SlackTextObjectType.PlainText };
        var builder = new SlackInputBlockBuilder()
            .WithLabel(_validLabel)
            .WithElement(_validElement)
            .WithDispatchAction(true)
            .WithHint(hint)
            .WithOptional(true);

        // Act
        var result = builder.Build() as SlackInputBlock;

        // Assert
        result.Should().NotBeNull();
        result?.Label.Should().Be(_validLabel);
        result?.Element.Should().BeOfType<SlackPlainTextInputElement>();
        result?.DispatchAction.Should().BeTrue();
        result?.Hint.Should().Be(hint);
        result?.Optional.Should().BeTrue();
    }

    [Fact]
    public void Build_Without_Label_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder()
            .WithElement(_validElement);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Label must have a value");
    }

    [Fact]
    public void Build_Without_Element_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder()
            .WithLabel(_validLabel);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Element must have a value");
    }

    [Fact]
    public void WithLabel_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder();

        // Act
        var result = builder.WithLabel(_validLabel);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder();

        // Act
        var result = builder.WithElement(_validElement);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithDispatchAction_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder();

        // Act
        var result = builder.WithDispatchAction(true);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithHint_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder();
        var hint = new SlackTextObject { Text = "Input Hint", Type = SlackTextObjectType.PlainText };

        // Act
        var result = builder.WithHint(hint);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithOptional_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackInputBlockBuilder();

        // Act
        var result = builder.WithOptional(true);

        // Assert
        result.Should().BeSameAs(builder);
    }
}