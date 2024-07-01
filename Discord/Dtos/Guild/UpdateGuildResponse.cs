namespace Discord.Dtos.Guild;

/// <summary>
/// Дто ответа на обновление сервера (гильдии)
/// </summary>
public class UpdateGuildResponse : BaseGuildDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}