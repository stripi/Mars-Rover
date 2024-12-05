using Mars_Rover;

namespace Test_Project
{
    public class Tests
    {
        public Rover testRover;
        public Rover testRover2;
        public Plateau testPlateau;

        [SetUp]
        public void Setup()
        {
            testRover = new Rover(0, 0, Enums.Orientation.N);
            testRover2 = new Rover(1, 0, Enums.Orientation.N);

            testPlateau = new Plateau(5, 5);
        }

        [Test]
        public void AddRoverToPlateau()
        {
            testPlateau.AddRover(testRover);
            Assert.That(testPlateau.Rovers.Contains(testRover), Is.True);
        }
        [Test]
        public void MoveRover()
        {
            testPlateau.AddRover(testRover);
            Assert.That(testPlateau.Rovers[0].Pos.ReadMovement("MM"), Is.EqualTo("0, 2, N"));
            
        }
        [Test]
        public void RotateRover()
        {
            testPlateau.AddRover(testRover);
            Assert.That(testPlateau.Rovers[0].Pos.ReadMovement("MRM"), Is.EqualTo("1, 1, E"));
        }
        [Test]
        public void MoveRoverOffGrid()
        {
            testPlateau.AddRover(testRover);
            Assert.That(testPlateau.Rovers[0].Pos.ReadMovement("MMMMMMM"), Is.EqualTo("0, 5, N"));
        }
        [Test]
        public void MoveMultipleRovers()
        {
            testPlateau.AddRover(testRover);
            testPlateau.AddRover(testRover2);
            Assert.That(testPlateau.Rovers[0].Pos.ReadMovement("M"), Is.EqualTo("0, 1, N"));
            Assert.That(testPlateau.Rovers[1].Pos.ReadMovement("M"), Is.EqualTo("1, 1, N"));
        }
        [Test]
        public void MoveRoverMultipleTimes()
        {
            testPlateau.AddRover(testRover);
            testPlateau.Rovers[0].Pos.ReadMovement("M");
            Assert.That(testPlateau.Rovers[0].Pos.ReadMovement("M"), Is.EqualTo("0, 2, N"));

        }

    }
}