using ComputergyAPI.DTOs;
using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.DTOs.Products;

namespace ComputergyAPI.Interfaces
{
    public interface IProducts
    {
        Task<ProductDTO> CreateProduct(ProductCreateDTO dto);
        Task<ProductDTO?> UpdateProduct(ProductUpdateDTO dto);
        Task<bool> RemoveProduct(int id);
        Task<List<ProductDTO>> GetAllProducts(PaginationParameters pagination);
        Task<ProductDTO?> GetOneProduct(int id);
        Task<List<ProductDTO>> SearchProduct(SearchInputProductsDTO input);
    }
}
