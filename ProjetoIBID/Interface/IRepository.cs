using ProjetoIBID.Model;

namespace ProjetoIBID.Interface
{
    public interface IRepository
    {
        public void CreateProduct(Product product);
        Product GetProduct(int id);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}