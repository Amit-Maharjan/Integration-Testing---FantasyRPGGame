using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ABattle
{
    [Test]
    public void ShouldReportThatCreature1WonTheDuel()
    {
        Creature creature1 = new()
        {
            Strength = 50,
            HitPoints = 100
        };

        Creature creature2 = new()
        {
            Strength = 0,
            HitPoints = 100
        };

        Battle sut = new();
        int result = sut.Duel(creature1, creature2);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void ShouldReportThatCreature2WonTheDuel()
    {
        Creature creature1 = new()
        {
            Strength = 0,
            HitPoints = 100
        };

        Creature creature2 = new()
        {
            Strength = 50,
            HitPoints = 100
        };

        Battle sut = new();
        int result = sut.Duel(creature1, creature2);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void ShouldReportATieForTheDuel()
    {
        Creature creature1 = new()
        {
            Strength = 1,
            HitPoints = 3
        };

        Creature creature2 = new()
        {
            Strength = 1,
            HitPoints = 3
        };

        Battle sut = new();
        int result = sut.Duel(creature1, creature2);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void CanReportTheDuelMessages()
    {
        Creature creature1 = new()
        {
            Strength = 1,
            HitPoints = 3
        };

        Creature creature2 = new()
        {
            Strength = 1,
            HitPoints = 3
        };

        Battle sut = new();
        _ = sut.Duel(creature1, creature2);
        Assert.That(sut.Message.Size(), Is.EqualTo(7));
    }
}
