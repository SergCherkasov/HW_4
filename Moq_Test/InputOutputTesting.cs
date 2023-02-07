using HW_4.UserInterface;
using Moq;
using static HW_4.UserInterface.UInterface;

namespace Moq_Test
{
    [TestClass]
    public class InputOutputTesting
    {
        [TestMethod]
        public void MoqTestIO()
        {
            var mock = new Mock<IInputOutput>();

            mock
                .Setup(x => x.Readline())
                .Returns("2+2");

            var simple = new UInterface(mock.Object);
            simple.Calculate();

            mock.Verify(x => x.WriteLine("4"), Times.Once);
        }
    }

}