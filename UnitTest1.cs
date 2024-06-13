using part1;
using ClassLibrary1;
using Laba10;
using ClassLibrary12_4;

namespace TestProject14
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AverageButtonCountAnalys_StackWithButtons_CalculatesAverageCorrectly()
        {
            // Arrange
            var stack = new Stack<Dictionary<string, ControlElement>>();
            var dict1 = new Dictionary<string, ControlElement>
            {
                { "Element1", new Button() },
                { "Element2", new TextBox() },
                { "Element3", new Button() }
            };
            stack.Push(dict1);

            // Act
            Analysis.AverageButtonCountAnalys(stack);

            // Assert
        }

        [TestMethod]
        public void GroupByElementTypeAnalys_StackWithMixedElements_GroupsCorrectly()
        {
            // Arrange
            var stack = new Stack<Dictionary<string, ControlElement>>();
            var dict1 = new Dictionary<string, ControlElement>
            {
                { "Element1", new Button() },
                { "Element2", new TextBox() },
                { "Element3", new TextBox() }
            };
            stack.Push(dict1);

            // Act
            Analysis.GroupByElementTypeAnalys(stack);

            // Assert
        }

        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string type = "ButtonControl";
            string location = "Location1";
            int capacity = 100;

            // Act
            var widgetManufacturer = new WidgetManufacturer(type, location, capacity);

            // Assert
            Assert.AreEqual(type, widgetManufacturer.WidgetType);
            Assert.AreEqual(location, widgetManufacturer.Location);
            Assert.AreEqual(capacity, widgetManufacturer.ProductionCapacity);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            string type = "ButtonControl";
            string location = "Location1";
            int capacity = 100;
            var widgetManufacturer = new WidgetManufacturer(type, location, capacity);

            // Act
            string result = widgetManufacturer.ToString();

            // Assert
            string expected = $"Тип виджета - {type}, Локация - {location}, Производственная мощность - {capacity}";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IntInput_ValidInput_ReturnsInteger()
        {
            // Arrange
            string input = "123";
            int expected = 123;

            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);

                // Act
                int result = part1.Utilities.IntInput("Enter an integer: ");

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void IntInput_InvalidInputThenValid_ReturnsInteger()
        {
            // Arrange
            string input = "abc\n123";
            int expected = 123;

            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);

                // Act
                int result = part1.Utilities.IntInput("Enter an integer: ");

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void SortByKeyNameAnalys_Test()
        {
            // Arrange
            var stack = new Stack<Dictionary<string, ControlElement>>();
            var dict1 = new Dictionary<string, ControlElement>
            {
                { "Key3", new Button() },
                { "Key1", new TextBox() },
                { "Key2", new Button() }
            };
            var dict2 = new Dictionary<string, ControlElement>
            {
                { "Key5", new TextBox() },
                { "Key4", new Button() }
            };
            stack.Push(dict1);
            stack.Push(dict2);

            // Act
            Analysis.SortByKeyNameAnalys(stack);

            // Assert 
        }

        [TestMethod]
        public void JoinWidgetManufacturerAnalys_Test()
        {
            // Arrange
            var stack = new Stack<Dictionary<string, ControlElement>>();
            var dict1 = new Dictionary<string, ControlElement>
            {
                { "Key1", new Button() },
                { "Key2", new TextBox() }
            };
            var dict2 = new Dictionary<string, ControlElement>
            {
                { "Key3", new TextBox() },
                { "Key4", new MultipleChoiceButton() }
            };
            stack.Push(dict1);
            stack.Push(dict2);

            var factories = new List<WidgetManufacturer>
            {
                new WidgetManufacturer("Button", "Location1", 100),
                new WidgetManufacturer("TextBox", "Location2", 150),
                new WidgetManufacturer("MultipleChoiceButton", "Location3", 200)
            };

            // Act
            Analysis.JoinWidgetManufacturerAnalys(stack, factories);

            // Assert 
        }

        [TestMethod]
        public void TextToKeyLengthRatioAnalys_Test()
        {
            // Arrange
            var stack = new Stack<Dictionary<string, ControlElement>>();
            var dict1 = new Dictionary<string, ControlElement>
            {
                { "Key1", new TextBox { Internaltext = "Text1" } },
                { "Key2", new TextBox { Internaltext = "Text22" } }
            };
            var dict2 = new Dictionary<string, ControlElement>
            {
                { "Key3", new Button() },
                { "Key4", new TextBox { Internaltext = "Text333" } }
            };
            stack.Push(dict1);
            stack.Push(dict2);

            // Act
            Analysis.TextToKeyLengthRatioAnalys(stack);

            // Assert 
        }
    }
}
