namespace ProyectoGrupo5.ViewModels
{
    public class ProductImageViewModel
    {
        public string Image { get; }

        public ProductViewModel ProductVM { get; }

        public ProductImageViewModel(string image, ProductViewModel productVM)
        {
            Image = image;
            ProductVM = productVM;
        }
    }
}
