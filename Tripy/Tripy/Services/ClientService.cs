using Tripy.Repositories;

namespace Tripy.Services;

public class ClientService : IClientService
{
    private IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public async Task<int> DeleteClient(int id)
    {
        return await _clientRepository.DeleteClient(id);
    }
}