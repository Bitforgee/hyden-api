namespace Hyden.Api.Core.Utils;

/// <summary>
/// Utilitário para gerenciar datas e horas no fuso horário de Cuiabá (Brasília - UTC-4)
/// </summary>
public static class DateTimeHelper
{
    private static readonly TimeZoneInfo CuiabaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

    /// <summary>
    /// Obtém a data e hora atual em Cuiabá
    /// </summary>
    public static DateTime NowCuiaba => TimeZoneInfo.ConvertTime(DateTime.UtcNow, CuiabaTimeZone);

    /// <summary>
    /// Obtém a data e hora atual em Cuiabá, mas mantendo Kind=UTC para PostgreSQL
    /// </summary>
    public static DateTime UtcNowCuiaba
    {
        get
        {
            var cuiabaTime = NowCuiaba;
            return new DateTime(cuiabaTime.Year, cuiabaTime.Month, cuiabaTime.Day, 
                cuiabaTime.Hour, cuiabaTime.Minute, cuiabaTime.Second, DateTimeKind.Utc);
        }
    }

    /// <summary>
    /// Converte uma data UTC para o fuso horário de Cuiabá
    /// </summary>
    public static DateTime ConvertUtcToCuiaba(DateTime utcDateTime)
    {
        if (utcDateTime.Kind != DateTimeKind.Utc)
            throw new ArgumentException("DateTime deve ter Kind=UTC", nameof(utcDateTime));

        return TimeZoneInfo.ConvertTime(utcDateTime, CuiabaTimeZone);
    }

    /// <summary>
    /// Converte uma data de Cuiabá para UTC
    /// </summary>
    public static DateTime ConvertCuiabaToUtc(DateTime cuiabaDateTime)
    {
        if (cuiabaDateTime.Kind != DateTimeKind.Unspecified)
            throw new ArgumentException("DateTime deve ter Kind=Unspecified", nameof(cuiabaDateTime));

        return TimeZoneInfo.ConvertTimeToUtc(cuiabaDateTime, CuiabaTimeZone);
    }
}
