using Microsoft.VisualBasic;
using ProjetoIBID.Interface;
using ProjetoIBID.Model;

namespace ProjetoIBID.Controller
{
    public class ProductController
    {
        private readonly IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateProduct()
        {
            Console.Clear();
            Console.Write("Digite o nome do produto: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o preço do produto: ");
            decimal price = decimal.Parse(Console.ReadLine());

            if(string.IsNullOrEmpty(name) || price <= 0)
            {
                Console.WriteLine("Nome ou preço inválido! Por favor insira os dados novamente!");
                Thread.Sleep(3000);
                CreateProduct();
            }

            Product product = new Product { Name = name, Price = price };

            _repository.CreateProduct(product);
            Console.WriteLine();
            Console.WriteLine("Produto criado com sucesso!");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void GetProduct()
        {
            Console.Clear();
            Console.Write("Digite o ID do produto que deseja buscar: ");
            int id = int.Parse(Console.ReadLine());

            var getProduct = _repository.GetProduct(id);

            if(getProduct == null)
            {
                Console.WriteLine();
                Console.WriteLine("ID não encontrado, digite um ID válido!");
                Thread.Sleep(3000);
                GetProduct();
            }

            Console.WriteLine("Produto encontrado com sucesso!");
            Console.WriteLine();
            Console.WriteLine($"Produto: {getProduct.Name}, Preço: R${getProduct.Price}");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void DeleteProduct()
        {
            Console.Clear();
            Console.Write("Digite o ID do produto que deseja remover: ");
            int IdRemove = int.Parse(Console.ReadLine());

            var productToDelete = _repository.GetProduct(IdRemove);

            if(productToDelete == null)
            {
                Console.WriteLine();
                Console.WriteLine("ID não encontrado, digite um ID válido!");
                Thread.Sleep(3000);
                DeleteProduct();
            }

            _repository.DeleteProduct(productToDelete);
            Console.WriteLine();
            Console.WriteLine("Produto removido com sucesso!");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void UpdateProduct()
        {
            Console.Clear();
            Console.Write("Digite o ID do produto que deseja editar: ");
            int productId = int.Parse(Console.ReadLine());

            var productToUpdate = _repository.GetProduct(productId);

            if(productToUpdate == null)
            {
                Console.WriteLine();
                Console.WriteLine("ID não encontrado, digite um ID válido!");
                Thread.Sleep(3000);
                UpdateProduct();
            }

            Console.Write("Digite o novo nome do produto: ");
            string nameUpdated = Console.ReadLine();
            Console.Write("Digite o novo preço do produto: ");
            decimal priceUpdated = decimal.Parse(Console.ReadLine());

            if(string.IsNullOrEmpty(nameUpdated) || priceUpdated <= 0)
            {
                Console.WriteLine("Nome ou preço inválido! Por favor insira os dados novamente!");
                Thread.Sleep(3000);
                UpdateProduct();
            }

            productToUpdate.Name = nameUpdated;
            productToUpdate.Price = priceUpdated;

            _repository.UpdateProduct(productToUpdate);
            Console.WriteLine();
            Console.WriteLine("Nome do produto editado com sucesso!");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}