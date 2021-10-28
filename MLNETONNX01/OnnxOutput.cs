using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNETONNX01
{
    public class OnnxOutput
    {
        [ColumnName("variable1")]
        public float[] PredictedFare { get; set; }
    }
}
