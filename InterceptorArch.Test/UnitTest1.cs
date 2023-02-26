namespace InterceptorArch.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
namespace InterceptorArch.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [SetUp]
        public void Setup()
        {
            // Delete the log file before each test
            File.Delete("log.txt");
        }

        [Test]
        public void PlayButtonPushed_LogsToLogFile()
        {
            // Arrange
            CdPlayer cdPlayer = new CdPlayer();
            var cdPlayerInterceptor = new FileLoggerInterceptor();
            var dispatcher = new Dispatcher();
            dispatcher.Attach(cdPlayerInterceptor);
            Button playButton = new Button(dispatcher, cdPlayer, "play");
            cdPlayer.SetPlayButton(playButton);

            // Act
            playButton.Push();

            // Assert
            string logContents = File.ReadAllText("log.txt");
            Assert.That(logContents, Does.Contain("play button pushed"));
        }

        [Test]
        public void StopButtonPushed_LogsToLogFile()
        {
            // Arrange
            CdPlayer cdPlayer = new CdPlayer();
            var cdPlayerInterceptor = new FileLoggerInterceptor();
            var dispatcher = new Dispatcher();
            dispatcher.Attach(cdPlayerInterceptor);
            Button stopButton = new Button(dispatcher, cdPlayer, "stop");
            cdPlayer.SetStopButton(stopButton);

            // Act
            stopButton.Push();

            // Assert
            string logContents = File.ReadAllText("log.txt");
            Assert.That(logContents, Does.Contain("stop button pushed"));
        }
    }
}