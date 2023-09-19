using ProjetoIBID.Controller;

namespace ProjetoIBID
{
    public class MenuApp
    {
        private readonly ProductController _productController;

        public MenuApp(ProductController productController)
        {
            _productController = productController;
        }
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1 - Cria um produto");
                Console.WriteLine("2 - Buscar um produto");
                Console.WriteLine("3 - Editar um produto");
                Console.WriteLine("4 - Excluir um produto");
                Console.WriteLine("5 - Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                int response = int.Parse(Console.ReadLine());

                switch(response)
                {
                    case 1:
                        _productController.CreateProduct();
                        break;
                    case 2:
                        _productController.GetProduct();
                        break;
                    case 3:
                        _productController.UpdateProduct();
                        break;
                    case 4:
                        _productController.DeleteProduct();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Escolha inválida");
                        break;
                }
            }
        }
    }
}