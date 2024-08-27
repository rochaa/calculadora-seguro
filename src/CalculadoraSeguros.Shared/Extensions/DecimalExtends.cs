using System.Globalization;

namespace System;

public static class DecimalExtends
{
    public static string ValorBR(this decimal value) => value.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
}