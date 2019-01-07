using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner.Test_Data_Classes
{
    public enum TestDataChartType { Pie, Column, Doughnut}

    public abstract class TestData : ITestData {

        protected Dictionary<string, int> ChartData;
        protected TestDataChartType ChartType;

        public abstract Dictionary<string, int> GetChartData();
        public abstract void AddData(string s, int i);
        public abstract TestDataChartType GetChartType();
    }

    public interface ITestData {
        Dictionary<string, int> GetChartData();
        void AddData(string s, int i);
        TestDataChartType GetChartType();
    }
}
