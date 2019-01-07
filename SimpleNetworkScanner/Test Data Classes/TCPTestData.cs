using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner.Test_Data_Classes
{
    public sealed class TCPTestData : TestData
    {
        public TCPTestData(TestDataChartType chartType)
        {
            ChartType = chartType;
            ChartData = new Dictionary<string, int>();
        }

        public override Dictionary<string, int> GetChartData()
        {
            return ChartData;
        }

        public override void AddData(string type, int value)
        {
            ChartData.Add(type, value);
        }

        public override TestDataChartType GetChartType() { return ChartType; }
    }
}
