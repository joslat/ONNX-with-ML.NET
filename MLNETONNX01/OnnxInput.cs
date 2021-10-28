using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Onnx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNETONNX01
{
    public class OnnxInput
    {        
        [ColumnName("vendorID"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 VendorID { get; set; }

        [ColumnName("day_of_month"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 DayOfMonth { get; set; }

        [ColumnName("day_of_week"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 DayOfWeek { get; set; }

        [ColumnName("hour_of_day"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 HourOfDay { get; set; }

        [ColumnName("month_num"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 MonthNum { get; set; }

        [ColumnName("passengerCount"), OnnxMapType(typeof(Int64), typeof(Single))]
        public Int64 PassengerCount { get; set; }

        [ColumnName("tripDistance")]
        public float TripDistance { get; set; }
    }
}
