using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner.Test_Data_Classes
{
    public sealed class PingTestData : TestData {

        public PingTestData(TestDataChartType chartType) {
            ChartType = chartType; 
            Data = new Dictionary<string, int>();
        }

        public override Dictionary<string, int> GetData() {
            return Data;
        }

        public override void AddData(string type, int value) {
            Data.Add(type, value);
        }

        public override TestDataChartType GetChartType() { return ChartType; }
    }
}
