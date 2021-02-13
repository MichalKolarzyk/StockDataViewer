using System;

namespace BaseModels
{
    public interface IPrice
    {
        DateTime Date { get; set; }
        float Value { get; set; }
    }
}