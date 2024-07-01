namespace Discord.Dtos.Guild;

/// <summary>
/// Дто ответа на создание сервера (гильдии)
/// </summary>
public class CreateGuildResponse : BaseGuildDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}