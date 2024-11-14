using FantasyRPG;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class AHuman
{
    [Test]
    public void ReportsItsRaceAsHuman()
    {
        Creature sut = new Human();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Human"));
    }

    //[Test]
    public void Has10PercentChanceOfInflictingDoubleDamage()
    {
        //IRandom random = Substitute.For<IRandom>();
        //random.Get(1, 30).Returns(25);
        //Creature sut = new(random)
        //{
        //    Strength = 30
        //};
        //int baseDamage = sut.InflictDamage();
        //Assert.That(baseDamage, Is.EqualTo(25));
    }
}
