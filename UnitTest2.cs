using part2;
using ClassLibrary1;
using Laba10;
using ClassLibrary12_4;
using System.Reflection.Emit;

namespace TestProject14
{
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void CountAnalys_Test()
        {
            // Arrange
            var collection = new MyCollection<ControlElement>();
            collection.Add(new TextBox { Internaltext = "Short" });
            collection.Add(new TextBox { Internaltext = "LongText" });
            collection.Add(new Button());

            // Act
            Analysis.CountAnalys(collection);

            // Assert
        }

        [TestMethod]
        public void AggregateAnalys_Test()
        {
            // Arrange
            var collection = new MyCollection<ControlElement>();
            collection.Add(new TextBox { Internaltext = "Short" });
            collection.Add(new TextBox { Internaltext = "LongText" });
            collection.Add(new Button());

            // Act
            Analysis.AggregateAnalys(collection);

            // Assert
        }

        [TestMethod]
        public void IntInput_ValidInput_ReturnsCorrectInteger()
        {
            // Arrange
            var input = "123\n";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            int result = Utilities.IntInput("Введите число: ");

            // Assert
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void WhereAnalys_ShouldPrintOnlyButtons()
        {
            // Arrange
            var collection = new MyCollection<ControlElement>
            {
                new Button { Id = "Button1" },
                new TextBox { Id = "Label1" },
                new Button { Id = "Button2" },
                new TextBox { Id = "Label2" },
                new TextBox { Id = "Label3" }
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Analysis.WhereAnalys(collection);

                // Assert
                var expected = "\nТОЛЬКО КНОПКИ\n\nButton1\nButton2\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void GroupAnalys_ShouldGroupByTypeAndPrintCounts()
        {
            // Arrange
            var collection = new MyCollection<ControlElement>
            {
                new Button { Id = "Button1" },
                new TextBox { Id = "Label1" },
                new Button { Id = "Button2" },
                new TextBox { Id = "Label2" },
                new TextBox { Id = "Label3" }
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Analysis.GroupAnalys(collection);

                // Assert
                var expected = "\nГРУППИРОВКА ПО ТИПУ ЭЛЕМЕНТА\nButton : 2\nLabel : 3\n";
                Assert.AreEqual(expected, sw.ToString().Replace("\r", ""));
            }
        }
    }
}
