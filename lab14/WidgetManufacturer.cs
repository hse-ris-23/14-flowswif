using System;

namespace part1
{
    public class WidgetManufacturer
    {
        private string widgetType;
        private string location;
        private int productionCapacity;

        public string WidgetType
        {
            get { return widgetType; }
            set { widgetType = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int ProductionCapacity
        {
            get { return productionCapacity; }
            set { productionCapacity = value; }
        }

        public WidgetManufacturer(string type, string location, int capacity)
        {
            WidgetType = type;
            Location = location;
            ProductionCapacity = capacity;
        }

        public override string ToString()
        {
            return $"Тип виджета - {WidgetType}, Локация - {Location}, Производственная мощность - {ProductionCapacity}";
        }
    }
}
