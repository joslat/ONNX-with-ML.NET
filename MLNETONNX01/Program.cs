using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Onnx;

namespace MLNETONNX01
{
    class Program
    {
        static string ONNX_MODEL_PATH = "ONNX/best_model.onnx";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello ONNX World!");
            
            MLContext mlContext = new MLContext();
            var onnxPredictionPipeline = GetPredictionPipeline(mlContext);
            var onnxPredictionEngine = mlContext.Model.CreatePredictionEngine<OnnxInput, OnnxOutput>(onnxPredictionPipeline);
            var testInput = new OnnxInput { 
                DayOfWeek= 1,
                HourOfDay= 19,
                DayOfMonth = 8,
                MonthNum= 12,
                PassengerCount= 1,
                VendorID = 2,
                TripDistance = 20
            };

            var prediction = onnxPredictionEngine.Predict(testInput);

            Console.WriteLine($"Predicted Fare: {prediction.PredictedFare.First()}");
        }

        static ITransformer GetPredictionPipeline(MLContext mlContext)
        {
            var inputColumns = new string[] { 
                "vendorID", "passengerCount", "tripDistance", "month_num", 
                "day_of_month", "day_of_week", "hour_of_day" 
            };
            var outputColumns = new string[] { "variable1" };
            var onnxPredictionPipeline =
                mlContext
                    .Transforms
                    .ApplyOnnxModel(
                        outputColumnNames: outputColumns,
                        inputColumnNames: inputColumns,
                        ONNX_MODEL_PATH);
            var emptyDv = mlContext.Data.LoadFromEnumerable(new OnnxInput[] { });

            return onnxPredictionPipeline.Fit(emptyDv);
        }
    }
}
