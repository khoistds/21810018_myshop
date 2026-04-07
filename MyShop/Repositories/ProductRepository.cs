using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repositories
{
    public class MockProductRepository : IRepo<Product, int>
    {
        List<Product> _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop Dell XPS 13", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Thiết kế sang trọng, hiệu năng mạnh mẽ.", CategoryId = 1, Price = 25000000, IsActive = true },
                new Product { Id = 2, Name = "iPhone 15 Pro", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Camera chuyên nghiệp, chip A17 Pro.", CategoryId = 2, Price = 28000000, IsActive = true },
                new Product { Id = 3, Name = "Bàn phím cơ Akko", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Switch gõ êm, đèn nền RGB rực rỡ.", CategoryId = 3, Price = 1500000, IsActive = true },
                new Product { Id = 4, Name = "MacBook Air M2", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Siêu mỏng nhẹ, pin dùng cả ngày.", CategoryId = 1, Price = 23000000, IsActive = true },
                new Product { Id = 5, Name = "Samsung Galaxy S24", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Màn hình Dynamic AMOLED đỉnh cao.", CategoryId = 2, Price = 21000000, IsActive = true },
                new Product { Id = 6, Name = "Chuột Logitech G502", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Cảm biến HERO 25K chính xác.", CategoryId = 3, Price = 1200000, IsActive = true },
                new Product { Id = 7, Name = "Màn hình LG 27 inch", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Độ phân giải 4K, màu sắc trung thực.", CategoryId = 3, Price = 8500000, IsActive = true },
                new Product { Id = 8, Name = "Tai nghe Sony WH-1000XM5", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Chống ồn chủ động tốt nhất thế giới.", CategoryId = 3, Price = 6500000, IsActive = true },
                new Product { Id = 9, Name = "iPad Pro M2", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Sức mạnh máy tính trong thân hình máy tính bảng.", CategoryId = 2, Price = 19000000, IsActive = true },
                new Product { Id = 10, Name = "Asus ROG Zephyrus", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Laptop gaming đỉnh cao cho game thủ chuyên nghiệp.", CategoryId = 1, Price = 45000000, IsActive = true },
                new Product { Id = 11, Name = "Loa Marshall Stanmore", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Âm thanh sống động, phong cách cổ điển.", CategoryId = 3, Price = 7200000, IsActive = true },
                new Product { Id = 12, Name = "Google Pixel 8 Pro", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Hệ điều hành Android thuần khiết, camera AI.", CategoryId = 2, Price = 18500000, IsActive = true },
                new Product { Id = 13, Name = "Surface Pro 9", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Thiết bị 2 trong 1 linh hoạt từ Microsoft.", CategoryId = 1, Price = 26000000, IsActive = true },
                new Product { Id = 14, Name = "Máy ảnh Fujifilm X-T5", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Chụp ảnh nghệ thuật với màu phim đặc trưng.", CategoryId = 3, Price = 42000000, IsActive = true },
                new Product { Id = 15, Name = "PlayStation 5", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Thế hệ console mới với tốc độ load cực nhanh.", CategoryId = 3, Price = 14500000, IsActive = true },
                new Product { Id = 16, Name = "Smartwatch Garmin Epix", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Đồng hồ GPS cao cấp cho vận động viên.", CategoryId = 2, Price = 22000000, IsActive = true },
                new Product { Id = 17, Name = "Ổ cứng SSD 1TB Samsung", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Tốc độ đọc ghi dữ liệu siêu nhanh.", CategoryId = 3, Price = 2800000, IsActive = true },
                new Product { Id = 18, Name = "Ghế Ergonomic Herman Miller", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Bảo vệ cột sống khi làm việc lâu.", CategoryId = 3, Price = 35000000, IsActive = true },
                new Product { Id = 19, Name = "Kindle Paperwhite 5", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Trải nghiệm đọc sách như trên giấy thật.", CategoryId = 2, Price = 3900000, IsActive = true },
                new Product { Id = 20, Name = "Bút Apple Pencil 2", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Phụ kiện không thể thiếu cho thiết kế trên iPad.", CategoryId = 3, Price = 2900000, IsActive = true },
                new Product { Id = 21, Name = "Nintendo Switch OLED", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Máy chơi game cầm tay màn hình rực rỡ.", CategoryId = 3, Price = 8200000, IsActive = true },
                new Product { Id = 22, Name = "Xiaomi 14 Ultra", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Ống kính Leica, cấu hình mạnh nhất thị trường.", CategoryId = 2, Price = 24500000, IsActive = true },
                new Product { Id = 23, Name = "Laptop HP Envy 16", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Sự cân bằng hoàn hảo giữa làm việc và giải trí.", CategoryId = 1, Price = 31000000, IsActive = true },
                new Product { Id = 24, Name = "Sạc dự phòng Anker 20k", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Dung lượng lớn, hỗ trợ sạc nhanh PD.", CategoryId = 3, Price = 1200000, IsActive = true },
                new Product { Id = 25, Name = "Bàn di chuột SteelSeries", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Kích thước lớn, bề mặt vải tối ưu cho game.", CategoryId = 3, Price = 600000, IsActive = true },
                new Product { Id = 26, Name = "Robot hút bụi Roborock", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Làm sạch thông minh, tự động đổ rác.", CategoryId = 3, Price = 13500000, IsActive = true },
                new Product { Id = 27, Name = "Máy chiếu Samsung Freestyle", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Rạp chiếu phim di động mọi lúc mọi nơi.", CategoryId = 3, Price = 15900000, IsActive = true },
                new Product { Id = 28, Name = "Apple Watch Ultra 2", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Đồng hồ thông minh bền bỉ cho thám hiểm.", CategoryId = 2, Price = 19500000, IsActive = true },
                new Product { Id = 29, Name = "Ram Corsair Vengeance 32GB", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Bus cao, hiệu năng ổn định cho PC.", CategoryId = 3, Price = 3200000, IsActive = true },
                new Product { Id = 30, Name = "Webcam Razer Kiyo Pro", ImageUrl = "/Assets/Products/no_image.jpg", Description = "Cảm biến ánh sáng tốt nhất cho streamer.", CategoryId = 3, Price = 4500000, IsActive = true }
            };

        public Task<PagedResult<Product>> GetAll(PagingRequest? info = null)
        {
            info ??= new();
            
            int totalItems = _products.Count;

            var items = _products
                .Skip((info.PageNumber - 1) * info.PageSize)
                .Take(info.PageSize)
                .ToList();
            var result = new PagedResult<Product>
            {
                Items = items,
                Pagination = new PagingMetadata
                {
                    TotalItems = totalItems,
                    PageNumber = info.PageNumber,
                    PageSize = info.PageSize,
                }
            };
            return Task.FromResult(result);
        }

        public Task<Product> Insert(Product newItem)
        {
            newItem.Id = _products.Max(p => p.Id) + 1;
            newItem.ImageUrl = "/Assets/Products/no_image.jpg";
            _products.Add(newItem);

            return Task.FromResult(newItem);
        }

        public Task<Product> Update(Product editItem)
        {
            var existItem = _products.First(p => p.Id == editItem.Id);

            existItem.Name = editItem.Name;
            existItem.CategoryId = editItem.CategoryId;
            existItem.ImageUrl = editItem.ImageUrl;
            existItem.Description = editItem.Description;
            existItem.Price = editItem.Price;

            return Task.FromResult(existItem);
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var deleteItem = _products.First(p => p.Id == id);

            _products.Remove(deleteItem);

            return true;
        }
    }
}
