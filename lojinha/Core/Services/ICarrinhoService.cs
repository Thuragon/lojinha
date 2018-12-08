using lojinha.Core.Models;
using System.Threading.Tasks;

namespace lojinha.Core.Services
{
    public interface ICarrinhoService
    {
        void Limpar(string usuario);
        Carrinho Obter(string usuario);
        void Salvar(string usuario, Carrinho carrinho);
    }
}