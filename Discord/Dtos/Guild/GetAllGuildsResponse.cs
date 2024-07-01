namespace Discord.Dtos.Guild;

/// <summary>
/// Дто ответа на получение всех серверов (гильдий)
/// </summary>
public class GetAllGuildsResponse : BaseGuildDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}