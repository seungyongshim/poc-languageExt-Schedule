using System;
using System.Threading.Tasks;
using FluentAssertions;
using LanguageExt;
using Xunit;
using static LanguageExt.Prelude;

namespace Sample.Tests;

public class PreludeSpec
{
    [Fact]
    public void Exponential1()
    {
        var t = Schedule.exponential(1 * sec) | Schedule.recurs(5);

        var r = t.Run();

        _ = r.Should().BeEquivalentTo(new Duration[]
        {
            1 * sec,
            2 * sec,
            4 * sec,
            8 * sec,
            16 * sec,
        });
    }

    [Fact]
    public void Fibonacci1()
    {
        var t = Schedule.fibonacci(1 * sec) | Schedule.recurs(6);

        var r = t.Run();

        _ = r.Should().BeEquivalentTo(new Duration[]
        {
            1 * sec,
            1 * sec,
            2 * sec,
            3 * sec,
            5 * sec,
            8 * sec
        });
    }

    [Fact]
    public void Fibonacci2()
    {
        var t = Schedule.fibonacci(1 * sec) | Schedule.maxDelay(5 * sec)| Schedule.recurs(8);

        var r = t.Run();

        _ = r.Should().BeEquivalentTo(new Duration[]
        {
            1 * sec,
            1 * sec,
            2 * sec,
            3 * sec,
            5 * sec,
            5 * sec,
            5 * sec,
            5 * sec,
        });
    }

    [Fact]
    public async Task FixedInterval()
    {
        var t = Schedule.fixedInterval(3 * sec) | Schedule.recurs(8);

        var r = t.Run();

        _ = r.Should().BeEquivalentTo(new Duration[]
        {
            3 * sec,
            3 * sec,
            3 * sec,
            3 * sec,
            3 * sec,
            3 * sec,
            3 * sec,
            3 * sec,
        });
    }
}
