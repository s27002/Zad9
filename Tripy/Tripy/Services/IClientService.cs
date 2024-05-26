namespace Tripy.Services;

public interface IClientService
{
    public Task<int> DeleteClient(int id);
}