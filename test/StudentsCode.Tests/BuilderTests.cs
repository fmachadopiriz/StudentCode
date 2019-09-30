using System;
using Xunit;
using Moq;
using Proyecto.Common;
using Proyecto.StudentsCode;

namespace StudentsCode.Tests
{
    public class BuilderTests
    {
        private void TestAction()
        {
            // Intencionalmente en blanco
        }

        [Fact]
        public void TestToDoAfterBuildIsSet()
        {
            Builder builder = new Builder();
            var mock = new Mock<IMainViewAdapter>();
            mock.Setup(library => library.ToDoAfterBuild(builder.AfterBuildShowFirstPage));
            IMainViewAdapter adapter = mock.Object;

            builder.Build(adapter);

            mock.Verify(library => library.ToDoAfterBuild(builder.AfterBuildShowFirstPage), Times.Once());
        }

        [Fact]
        public void TestTwoPagesAdded()
        {
            Builder builder = new Builder();
            var mock = new Mock<IMainViewAdapter>();
            mock.Setup(library => library.AddPage());
            IMainViewAdapter adapter = mock.Object;
            
            builder.Build(adapter);
            
            mock.Verify(library => library.AddPage(), Times.Exactly(2));            
        }
    }
}
