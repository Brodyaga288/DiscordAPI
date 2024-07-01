namespace Discord.Dtos.Guild;

/// <summary>
/// Дто ответа на получение сервера (гильдии) по идентификатору
/// </summary>
public class GetByIdGuildResponse : BaseGuildDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}