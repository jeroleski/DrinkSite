namespace DrinkSite.Core;

public interface IUseRepository
{
    Task<(Status, UseDto)> CreateAsync(UseCreateDto use);
    Task<UseDto?> ReadAsync(int useId);
    Task<IReadOnlyCollection<UseDto>> ReadAsync();
    Task<Status> UpdateAsync(UseDto use);
    Task<Status> DeleteAsync(int useId);
}