namespace Tripy.Repositories;

public interface IClientRepository
{
    public Task<int> DeleteClient(int id);
}